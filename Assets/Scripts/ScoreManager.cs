/*using UnityEngine;
using TMPro; // Подключаем TextMesh Pro

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0; // Счетчик очков
    public TMPro.TextMeshProUGUI scoreText; // Ссылка на текстовый компонент TextMesh Pro
    public TMPro.TextMeshProUGUI endScoreText; // Ссылка на текстовый компонент TextMesh Pro

    void Start()
    {
        UpdateScoreText(); // Обновляем текстовый компонент при запуске
    }

    public void AddScore(int amount)
    {
        currentScore += amount; // Увеличиваем счет
        UpdateScoreText(); // Обновляем текст
    }

    public void ResetScore()
    {
        currentScore = 0; // Сбрасываем счетчик очков
        UpdateScoreText(); // Обновляем текст
    }

    private void UpdateScoreText()
    {
        if (scoreText != null) // Если текстовый компонент установлен
        {
            scoreText.text = "Score: " + currentScore.ToString(); // Обновляем текст очков
            endScoreText.text = "Score: " + currentScore.ToString(); // Обновляем текст очков
        }
    }
}*/
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Подключаем TextMesh Pro

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0; // Счетчик очков
    public TMPro.TextMeshProUGUI scoreText; // Ссылка на текстовый компонент TextMesh Pro
    public TMPro.TextMeshProUGUI winEndScoreText;
    public TMPro.TextMeshProUGUI loseEndScoreText;
    // Ссылка на текстовый компонент TextMesh Pro

    public GameObject WinScreen;
    public GameObject winButton;

    void Start()
    {
        UpdateScoreText(); // Обновляем текстовый компонент при запуске
    }

    public void AddScore(int amount)
    {
        currentScore += amount; // Увеличиваем счет
        if (currentScore >= LevelData.scoreCount)
        {
             WinScreen.SetActive(true);
             FindObjectOfType<Timer>().StopTimer();
             LevelProgressManager.Instance.CompleteLevel(LevelData.currentLevel);
             var _levelSelector = FindObjectOfType<LevelSelector>();
             winButton.GetComponent<Button>().onClick.AddListener(() => _levelSelector.SelectLevel(LevelData.currentLevel+1));
        }
        UpdateScoreText(); // Обновляем текст
    }

    public void ResetScore()
    {
        currentScore = 0; // Сбрасываем счетчик очков
        UpdateScoreText(); // Обновляем текст
    }

    private void UpdateScoreText()
    {
        if (scoreText != null) // Если текстовый компонент установлен
        {
            scoreText.text = "Score: " + currentScore.ToString() + "/" + LevelData.scoreCount; // Обновляем текст очков
            winEndScoreText.text = "Points:" + currentScore.ToString() + "/" + LevelData.scoreCount; 
            loseEndScoreText.text = "Points:" + currentScore.ToString() + "/" + LevelData.scoreCount; 
        }
    }
}