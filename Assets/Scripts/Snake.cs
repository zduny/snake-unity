using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Snake : IEnumerable<IntVector2>
{
    /// <summary>
    /// Queue holding snake's body parts positions.
    /// </summary>
    private LinkedList<IntVector2> body;

    /// <summary>
    /// Stores buldges locations
    /// </summary>
    private HashSet<IntVector2> bulges;

    /// <summary>
    /// Game board.
    /// </summary>
    private Board board;

    /// <summary>
    /// Gets snake's head position.
    /// </summary>
    public IntVector2 Head
    {
        get
        {
            return body.Last.Value;
        }
    }

    public Snake(Board board)
    {
        this.board = board;
        body = new LinkedList<IntVector2>();
        bulges = new HashSet<IntVector2>();
        Reset();
    }

    /// <summary>
    /// Hides the snake.
    /// </summary>
    public void Hide()
    {
        foreach (var p in body)
        {
            board[p].ContentHidden = true;
        }
    }

    /// <summary>
    /// Shows the snake.
    /// </summary>
    public void Show()
    {
        foreach (var p in body)
        {
            board[p].ContentHidden = false;
        }
    }

    /// <summary>
    /// Resets snake to original position.
    /// </summary>
    public void Reset()
    {
        foreach (var p in body)
        {
            board[p].Content = TileContent.Empty;
        }

        body.Clear();
        bulges.Clear();

        var start = new IntVector2(5, 13);
        for (int i = 0; i < 5; i++)
        {
            var position = new IntVector2(start.x, start.y - i);
            body.AddLast(position);
            board[position].Content = TileContent.SnakesBody;
        }
    }

    /// <summary>
    /// Moves snake to new position according to direction of movement.
    /// </summary>
    /// <param name="direction">direction of movement</param>
    /// <param name="extend">if true snake will be extended by one segment</param>
    public void Move(IntVector2 direction, bool extend)
    {
        var newHead = NextHeadPosition(direction);

        body.AddLast(newHead);
        if (extend)
        {
            bulges.Add(newHead);
        }
        else
        {
            bulges.Remove(body.First.Value);
            body.RemoveFirst();
        }

        var tile = board[newHead];
        tile.Content = TileContent.SnakesHead;
        if (direction == Vector2.up)
        {
            tile.ZRotation = 0;
        }
        else if (direction == Vector2.down)
        {
            tile.ZRotation = 180;
        }
        else if (direction == Vector2.left)
        {
            tile.ZRotation = -90;
        }
        else if (direction == Vector2.right)
        {
            tile.ZRotation = 90;
        }

        var last = body.Last;
    }

    /// <summary>
    /// Gets next snake's head position
    /// </summary>
    /// <param name="direction">direction of movement</param>
    /// <returns></returns>
    public IntVector2 NextHeadPosition(IntVector2 direction)
    {
        return Head + new IntVector2(direction.x, -direction.y);
    }

    public IEnumerator<IntVector2> GetEnumerator()
    {
        return ((IEnumerable<IntVector2>)body).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<IntVector2>)body).GetEnumerator();
    }
}
