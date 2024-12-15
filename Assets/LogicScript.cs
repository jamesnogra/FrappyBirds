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
    public GameObject pauseButton;
    public float scoreDivisor, moveSpeed;

    void Start()
    {
        playerScore = 0;
        moveSpeed = 5;
        scoreDivisor = 10;
        updateDisplayScoreBoard();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        updateDisplayScoreBoard();
        // Increase speed for every point
        float moveSpeedToAdd = playerScore / scoreDivisor;
        moveSpeed += moveSpeedToAdd;
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
        pauseButton.SetActive(false); // Hide pause button
        gameOverScreen.SetActive(true); // Show game over screen
        Time.timeScale = 0;
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
        pauseButton.SetActive(false); // Hide pause button
        pauseScreen.SetActive(true); // Show puase screen
        Time.timeScale = 0;
        pauseScreenCurrentScoreText.text = "Current Score: " + playerScore.ToString();
        // Get current high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        pauseScreenHighScoreText.text = "High Score: " + highScore.ToString();
    }

    public void continueGame()
    {
        pauseButton.SetActive(true); // Show pause button
        pauseScreen.SetActive(false); // Hide the pause screen
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
