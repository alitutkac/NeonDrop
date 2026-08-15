using System.Collections;
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

    [Header("Zorluk / Hız Ayarları")]
    public float baseSpeed = 5f;
    public float maxSpeed = 15f;
    public float acceleration = 0.15f;

    [HideInInspector]
    public float currentObstacleSpeed;

    private float score = 0f;
    private int highScore = 0;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        currentObstacleSpeed = baseSpeed;

        // Hafızadaki en yüksek skoru çek ve ekrana yaz
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
            highScoreText.text = "BEST: " + highScore.ToString();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Skor artışı
            score += Time.deltaTime * 10f;
            if (scoreText != null)
                scoreText.text = ((int)score).ToString();

            // Hız artışı
            if (currentObstacleSpeed < maxSpeed)
            {
                currentObstacleSpeed += acceleration * Time.deltaTime;
            }
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        // Yeni rekor kırıldıysa kaydet
        if ((int)score > highScore)
        {
            highScore = (int)score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        StartCoroutine(ScreenShakeAndStop());
    }

    private IEnumerator ScreenShakeAndStop()
    {
        Transform camTransform = Camera.main.transform;
        Vector3 originalPos = camTransform.position;
        float elapsed = 0f;
        float duration = 0.2f;
        float magnitude = 0.3f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            camTransform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        camTransform.position = originalPos;
        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}