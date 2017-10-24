using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class Game : MonoBehaviour
{
    /// <summary>
    /// Variable used for game update delay calcuations.
    /// </summary>
    private float time;

    private Snake snake;

    /// <summary>
    /// Position of an apple (1 point fruit).
    /// </summary>
    private IntVector2 applePosition;

    /// <summary>
    /// Position of 10 point (bonus) fruit.
    /// </summary>
    private IntVector2 bonusPosition;

    /// <summary>
    /// Specifies if bonus is visible and active.
    /// </summary>
    private bool bonusActive;

    /// <summary>
    /// Game controller.
    /// </summary>
    private Controller controller;

    /// <summary>
    /// Menu panel.
    /// </summary>
    public MenuPanel Menu;
    /// <summary>
    /// Game over panel.
    /// </summary>
    public GameOverPanel GameOver;
    /// <summary>
    /// Main game panel (with board).
    /// </summary>
    public GamePanel GamePanel;

    /// <summary>
    /// Parameter specyfying delay between snake movements (in seconds).
    /// </summary>
    [Range(0f, 3f)]
    public float GameSpeed;

    /// <summary>
    /// Has to be set to game's board object.
    /// </summary>
    public Board Board;

    private int _score;
    private int _highScore;

    /// <summary>
    /// Current score.
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
            GamePanel.Score = value;
            GameOver.Score = value;

            if (value > HighScore)
            {
                HighScore = value;
            }
        }
    }

    /// <summary>
    /// Current high score.
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
            PlayerPrefs.SetInt("High Score", value);
            GamePanel.HighScore = value;
            Menu.HighScore = value;
        }
    }

    /// <summary>
    /// Determines if games is paused (when true) or running (when false).
    /// </summary>
    public bool Paused { get; private set; }

    // Use this for initialization
    void Start()
    {
        // Display current high score.
        HighScore = PlayerPrefs.GetInt("High Score", 0);

        // Show main menu
        ShowMenu();

        // Set controller
        controller = GetComponent<Controller>();

        // Creates snake
        snake = new Snake(Board);

        // Pause the game
        Paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        while (time > GameSpeed)
        {
            time -= GameSpeed;
            UpdateGameState();
        }
    }

    /// <summary>
    /// Updates game state.
    /// </summary>
    private void UpdateGameState()
    {
        if (!Paused && snake != null)
        {
            var head = snake.Head;
            var dir = controller.NextDirection();

            // New head position
            head += new IntVector2(dir.x, -dir.y);

            var x = head.x;
            var y = head.y;

            if (snake.Contains(head))
            {
                // Snake has bitten its tail - game over
                StartCoroutine(GameOverCoroutine());
                return;
            }

            if (x >= 0 && x < Board.Columns && y >= 0 && y < Board.Rows)
            {
                snake.AddHead(head);

                if (head == applePosition)
                {
                    Score += 1;
                    PlantAnApple();
                }
                else
                {
                    snake.RemoveTail();
                }
            }
            else
            {
                // Head is outside board's bounds - game over.
                StartCoroutine(GameOverCoroutine());
            }
        }
    }

    /// <summary>
    /// Shows main menu.
    /// </summary>
    public void ShowMenu()
    {
        HideAllPanels();
        Menu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Shows game over panel.
    /// </summary>
    public void ShowGameOver()
    {
        HideAllPanels();
        GameOver.gameObject.SetActive(true);
    }

    /// <summary>
    /// Shows the board and starts the game.
    /// </summary>
    public void StartGame()
    {
        HideAllPanels();
        Restart();
        GamePanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides all panels.
    /// </summary>
    private void HideAllPanels()
    {
        Menu.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
    }

    /// <summary>
    /// Returns game to initial conditions.
    /// </summary>
    private void Restart()
    {
        // Resets the controller.
        controller.Reset();

        // Set score
        Score = 0;

        // Disable bonus
        bonusActive = false;

        // Clear board
        foreach (var tile in Board)
        {
            tile.Content = TileContent.Empty;
        }

        // Resets snake
        snake.Reset();

        // Plant an apple
        PlantAnApple();

        // Start the game
        Paused = false;
        time = 0;
    }

    /// <summary>
    /// Puts an apple in new position.
    /// </summary>
    private void PlantAnApple()
    {
        if (Board[applePosition].Content == TileContent.Apple)
        {
            Board[applePosition].Content = TileContent.Empty;
        }

        applePosition = Board.EmptyPositions.ToList().RandomElement();
        Board[applePosition].Content = TileContent.Apple;
    }

    /// <summary>
    /// Courotine that is started when game is over. Causes snake to blink and then shows game over panel.
    /// </summary>
    /// <returns></returns>
    private IEnumerator GameOverCoroutine()
    {
        // Pause the game
        Paused = true;

        // Start snake blinking
        for (int i = 0; i < 3; i++)
        {
            snake.Hide();
            yield return new WaitForSeconds(GameSpeed * 1.5f);
            snake.Show();
            yield return new WaitForSeconds(GameSpeed * 1.5f);
        }

        // Show "game over" panel
        ShowGameOver();
    }
}
