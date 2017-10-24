using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    /// <summary>
    /// Text displayed before score value. 
    /// </summary>
    private String textPrefix;

    /// <summary>
    /// Text showing high score.
    /// </summary>
    private Text textHighScore;

    private int _highScore;

    /// <summary>
    /// Gets or sets currently displayed high score.
    /// </summary>
    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            _highScore = value;
            textHighScore.text = textPrefix + value.ToString();
        }
    }

    // Use this for initialization
    void Awake()
    {
        textHighScore = transform.Find("High Score").GetComponent<Text>();
        textPrefix = textHighScore.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
