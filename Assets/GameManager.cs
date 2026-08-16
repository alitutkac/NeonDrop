using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elemanları")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject pauseButton;

    [Header("Zorluk / Hız Ayarları")]
    public float baseSpeed = 5f;
    public float maxSpeed = 15f;
    public float acceleration = 0.15f;
    public float currentObstacleSpeed;

    private float scoreCounter = 0f;
    private int score = 0;
    private int highScore = 0;
    private bool isGameOver = false;
    private bool isPaused = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
        currentObstacleSpeed = baseSpeed;
        scoreCounter = 0f;
        score = 0;
        isGameOver = false;
        isPaused = false;

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    void Update()
    {
        if (!isGameOver && !isPaused)
        {
            // Hızlanma
            if (currentObstacleSpeed < maxSpeed)
            {
                currentObstacleSpeed += acceleration * Time.deltaTime;
            }

            // Sürekli ve seri skor artışı (Saniyede 5 skor hızı)
            scoreCounter += Time.deltaTime * 5f;
            int newScore = Mathf.FloorToInt(scoreCounter);

            if (newScore > score)
            {
                score = newScore;
                if (score > highScore)
                {
                    highScore = score;
                    PlayerPrefs.SetInt("HighScore", highScore);
                }
                UpdateScoreUI();
            }
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver || isPaused) return;
        score += amount;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = score.ToString();
        if (highScoreText != null) highScoreText.text = "BEST : " + highScore.ToString();
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (pauseButton != null) pauseButton.SetActive(false);
    }

    public void PauseGame()
    {
        if (isGameOver) return;
        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null) pausePanel.SetActive(true);
        if (pauseButton != null) pauseButton.SetActive(false);
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null) pausePanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}