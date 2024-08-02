using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float duration = 60f; // Начальное время таймера в секундах
    private float currentTime;   // Текущее время таймера
    private bool isRunning = false; // Флаг, запущен ли таймер
    
    public TMPro.TextMeshProUGUI timerText; // Ссылка на текстовый компонент TextMesh Pro// Ссылка на текстовый компонент TextMesh Pro

    [SerializeField]
    private GameObject _loseScreen;

    //[SerializeField] private Slider _slider;

    [SerializeField] private TextMeshProUGUI _loseWinText;
    

    void Start()
    {
        ResetTimer(); // Сбрасываем таймер
        currentTime = LevelData.selectedTime;
        UpdateTimerText(); // Обновляем текст таймера
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime; // Уменьшаем текущее время
            if (currentTime <= 0)
            {
                isRunning = false; // Останавливаем таймер
                currentTime = 0; // Устанавливаем время в 0
                HandleTimeEnd();
            }
            UpdateTimerText(); // Обновляем текст таймера
        }
    }

    private void HandleTimeEnd()
    {
        _loseScreen.SetActive(true);
        //_loseWinText.SetText("You lose!");
    }

    public void HandleNextLevel()
    {
          LevelProgressManager.Instance.CompleteLevel(LevelData.currentLevel);
        SceneManager.LoadScene("PickLevelsScene");
    }

    public void StartTimer()
    {
        isRunning = true; // Запускаем таймер
    }

    public void StopTimer()
    {
        isRunning = false; // Останавливаем таймер
    }

    public void ResetTimer()
    {
        currentTime = duration; // Сбрасываем время таймера
        UpdateTimerText(); // Обновляем текст таймера
    }

    private void UpdateTimerText()
    {
        if (timerText != null) // Если компонент TextMesh Pro установлен
        {
            // Получаем минуты и секунды из текущего времени
            int minutes = (int)(currentTime / 60); 
            int seconds = (int)(currentTime % 60);

            //_slider.value =currentTime/(float)LevelData.selectedTime;
            
            // Форматируем как MM:SS
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}