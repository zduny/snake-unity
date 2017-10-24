using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
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

    private RectTransform rectTransform;

    // Use this for initialization
    void Start()
    {
        rectTransform = transform as RectTransform;

        // Calculate tile size (assuming board always have to fit whole panel's width).
        var width = rectTransform.rect.width;
        var tileSize = (width - Margins * 2) / Columns;

        // Change panel height to contain tiles.
        rectTransform.sizeDelta = new Vector2(width, tileSize * Rows + Margins * 2);

        // Fill board with rows * columns number of tiles
        float x = Margins;
        float y = Margins;

        for (int i = 0; i < Rows; i++)
        {
            x = Margins;
            for (int j = 0; j < Columns; j++)
            {
                var tile = (GameObject)Instantiate(TilePrefab, new Vector3(x, -y, 0), Quaternion.identity);
                tile.transform.SetParent(rectTransform, false);
                var rect = tile.transform as RectTransform;
                rect.sizeDelta = new Vector2(tileSize, tileSize);

                x += tileSize;
            }

            y += tileSize;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
