using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
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
    }

    public void pauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
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
