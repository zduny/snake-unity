using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;

public class Snake : IEnumerable<IntVector2>
{
    /// <summary>
    /// Queue holding snake's body parts positions.
    /// </summary>
    private Queue<IntVector2> body;

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
            return body.Last();
        }
    }

    public Snake(Board board)
    {
        this.board = board;
        body = new Queue<IntVector2>();
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

        var start = new IntVector2(5, 13);
        for (int i = 0; i < 5; i++)
        {
            var position = new IntVector2(start.x, start.y - i);
            body.Enqueue(position);
            board[position].Content = TileContent.Snake;
        }
    }

    /// <summary>
    /// Adds head at given position.
    /// </summary>
    /// <param name="head">new head's position</param>
    public void AddHead(IntVector2 head)
    {
        body.Enqueue(head);
        board[head].Content = TileContent.Snake;
    }

    /// <summary>
    /// Removes tail.
    /// </summary>
    /// <returns>last tail position</returns>
    public IntVector2 RemoveTail()
    {
        var tail = body.Dequeue();
        board[tail].Content = TileContent.Empty;

        return tail;
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
