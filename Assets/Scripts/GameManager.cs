using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;

    public int lives = 3;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        if (isGameOver) return;

        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("GAME OVER! Final score: " + score);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}