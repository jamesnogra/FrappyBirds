using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text pauseScreenCurrentScoreText;
    public Text pauseScreenHighScoreText;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public float scoreDivisor = 10;

    void Start()
    {
        playerScore = 0;
        updateDisplayScoreBoard();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        updateDisplayScoreBoard();
    }

    private void updateDisplayScoreBoard()
    {
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        // Check if we need to save this high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();
        }
    }

    public void pauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        pauseScreenCurrentScoreText.text = "Current Score: " + playerScore.ToString();
        // Get current high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        pauseScreenHighScoreText.text = "High Score: " + highScore.ToString();
    }

    public void continueGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
