using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons; // Массив кнопок для выбора уровня
    public int[] levelTimes; // Время для каждого уровня
    public int[] levelScores;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i;
            levelButtons[i].onClick.AddListener(() => SelectLevel(levelIndex)); // Добавляем слушатель событий к каждой кнопке
        }
    }

    public void SelectLevel(int levelIndex)
    {
        int selectedTime = levelTimes[levelIndex]; // Получаем время для выбранного уровня
        LevelData.selectedTime = selectedTime; // Сохраняем время в статическую переменную
        LevelData.currentLevel = levelIndex;
        LevelData.scoreCount = levelScores[levelIndex];
        LoadLevel(); // Загружаем игровую сцену
    }

    private void LoadLevel()
    {
        // Здесь нужно указать имя сцены, которая будет использоваться для всех уровней
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}