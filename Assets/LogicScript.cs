using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

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
    }
}
