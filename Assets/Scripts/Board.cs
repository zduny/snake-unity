using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class Board : MonoBehaviour, IEnumerable<Tile>
{
    /// <summary>
    /// RectTransform of the board.
    /// </summary>
    private RectTransform rectTransform;
    /// <summary>
    /// List holding all the tiles.
    /// </summary>
    private List<Tile> tiles;

    /// <summary>
    /// Specifies prefab used to create tiles;
    /// </summary>
    public GameObject TilePrefab;

    /// <summary>
    /// Specifies number of board columns (horizontal size).
    /// </summary>
    [Range(0, 30)]
    public int Columns = 10;

    /// <summary>
    /// Specifies number of board rows (vertical size).
    /// </summary>
    [Range(0, 30)]
    public int Rows = 15;

    /// <summary>
    /// Specifies board margins size (walls thickness).
    /// </summary>
    [Range(0, 20f)]
    public float Margins = 3;

    /// <summary>
    /// All possible positions in board.
    /// </summary>
    public IEnumerable<IntVector2> Positions
    {
        get
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < Rows; i++)
            {
                x = 0;
                for (int j = 0; j < Columns; j++)
                {
                    yield return new IntVector2(x, y);

                    x++;
                }

                y++;
            }
        }
    }

    /// <summary>
    /// All empty positions (all positions where tile's content is empty).
    /// </summary>
    public IEnumerable<IntVector2> EmptyPositions
    {
        get
        {
            return Positions.Where((p) => { return this[p].Content == TileContent.Empty; });
        }
    }

    // Use this for initialization
    void Awake()
    {
        rectTransform = transform as RectTransform;

        // Calculate tile size (assuming board always have to fit whole panel's width).
        var width = rectTransform.rect.width;
        var tileSize = (width - Margins * 2) / Columns;
        var halfTileSize = tileSize / 2;

        // Change panel height to contain tiles.
        rectTransform.sizeDelta = new Vector2(width, tileSize * Rows + Margins * 2);

        // Fill the board with rows*columns number of tiles
        tiles = new List<Tile>();

        float x = Margins;
        float y = Margins;

        for (int i = 0; i < Rows; i++)
        {
            x = Margins;
            for (int j = 0; j < Columns; j++)
            {
                var tile = Instantiate(TilePrefab, new Vector3(x + halfTileSize, -y - halfTileSize, 0), Quaternion.identity).GetComponent<Tile>();
                tile.transform.SetParent(rectTransform, false);
                tile.RectTransform.sizeDelta = new Vector2(tileSize, tileSize);
                tiles.Add(tile);

                x += tileSize;
            }

            y += tileSize;
        }

        this[5, 5].Content = TileContent.Apple;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator<Tile> GetEnumerator()
    {
        return ((IEnumerable<Tile>)tiles).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Tile>)tiles).GetEnumerator();
    }

    /// <summary>
    /// Indexer for retrieving tiles at given position.
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <returns>tile at given position</returns>
    public Tile this[int x, int y]
    {
        get
        {
            if (!(x >= 0 && x < Columns))
            {
                throw new System.ArgumentOutOfRangeException("x", "x coordinate must be between 0 and the number of columns.");
            }

            if (!(y >= 0 && y < Rows))
            {
                throw new System.ArgumentOutOfRangeException("y", "y coordinate must be between 0 and the number of rows.");
            }

            return tiles[y * Columns + x];
        }
    }

    /// <summary>
    /// Indexer for retrieving tiles at given position.
    /// </summary>
    /// <param name="position">coordinates of wanted tile</param>
    /// <returns>tile at given position</returns>
    public Tile this[IntVector2 position]
    {
        get
        {
            return this[position.x, position.y];
        }
    }

    /// <summary>
    /// Resets board to original conditions.
    /// </summary>
    public void Reset()
    {
        foreach (var tile in this)
        {
            tile.Reset();
        }
    }
}
