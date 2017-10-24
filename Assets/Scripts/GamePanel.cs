using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {
    /// <summary>
    /// Text showing current score.
    /// </summary>
    private Text textScore;
    /// <summary>
    /// Text showing high score.
    /// </summary>
    private Text textHighScore;

    private int _score;
    private int _highScore;

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
            textScore.text = value.ToString();
        }
    }

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
            textHighScore.text = value.ToString();
        }
    }

    // Use this for initialization
    void Awake () {
        textScore = transform.Find("Score").GetComponent<Text>();
        textHighScore = transform.Find("High Score").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
