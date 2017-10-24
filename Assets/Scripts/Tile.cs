using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class Tile : MonoBehaviour
{
    /// <summary>
    /// Sprite for empty tile.
    /// </summary>
    public Sprite Empty;
    /// <summary>
    /// Sprite for normal fruit (1 point).
    /// </summary>
    public Sprite Apple;
    /// <summary>
    /// Sprite for body of snake.
    /// </summary>
    public Sprite Snake;
    /// <summary>
    /// List of sprites representing bonus fruit (10 points fruit).
    /// </summary>
    public List<Sprite> Bonuses;

    /// <summary>
    /// Image component of this GameObject.
    /// </summary>
    private Image image;
    private RectTransform _rectTransform;
    private TileContent _content;
    private bool _contentHidden;

    /// <summary>
    /// Rect Transform component of this tile.
    /// </summary>
    public RectTransform RectTransform
    {
        get
        {
            return _rectTransform;
        }
    }

    /// <summary>
    /// Contents of this tile.
    /// </summary>
    public TileContent Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
            switch (_content)
            {
                case TileContent.Empty:
                    image.sprite = Empty;
                    break;
                case TileContent.Apple:
                    image.sprite = Apple;
                    break;
                case TileContent.Bonus:
                    image.sprite = Bonuses.RandomElement();
                    break;
                case TileContent.Snake:
                    image.sprite = Snake;
                    break;
            }
        }
    }

    /// <summary>
    /// If true tile's content will be hidden (as if content was empty). Used for blinking.
    /// </summary>
    public bool ContentHidden
    {
        get
        {
            return _contentHidden;
        }
        set
        {
            _contentHidden = value;
            if (value)
            {
                image.sprite = Empty;
            }
            else
            {
                Content = Content;
            }
        }
    }

    // Use this for initialization
    void Awake()
    {
        image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        Content = TileContent.Empty;
        _contentHidden = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
