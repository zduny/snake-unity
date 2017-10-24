using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    /// <summary>
    /// Text displayed before score value. 
    /// </summary>
    private String textPrefix;

    /// <summary>
    /// Text showing high score.
    /// </summary>
    private Text textScore;

    private int _score;

    /// <summary>
    /// Gets or sets currently displayed score.
    /// </summary>
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            textScore.text = textPrefix + value.ToString();
        }
    }

    // Use this for initialization
    void Awake()
    {
        textScore = transform.Find("Score").GetComponent<Text>();
        textPrefix = textScore.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}