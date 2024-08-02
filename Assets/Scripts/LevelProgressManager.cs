using System.Collections.Generic;
using UnityEngine;

public class LevelProgressManager : MonoBehaviour
{
    public static LevelProgressManager Instance { get; private set; } // Синглтон
    public int totalLevels = 9; // Общее количество уровней в игре

    private HashSet<int> unlockedLevels; // Хранение разблокированных уровней

    void Awake()
    {
        // Паттерн Singleton: только один экземпляр LevelProgressManager
        if (Instance == null)
        {
            Instance = this; // Если не существует, устанавливаем текущий объект как синглтон
            DontDestroyOnLoad(gameObject); // Обеспечиваем, чтобы объект не уничтожался при загрузке новой сцены
            unlockedLevels = new HashSet<int>(); // Инициализация коллекции разблокированных уровней
            UnlockLevel(0); // По умолчанию, первый уровень разблокирован
        }
        else
        {
            Destroy(gameObject); // Если существует другой экземпляр, уничтожаем текущий
        }
    }

    public void UnlockLevel(int levelNumber)
    {
        if (levelNumber <= totalLevels)
        {
            unlockedLevels.Add(levelNumber); // Разблокируем указанный уровень
        }
    }

    public bool IsLevelUnlocked(int levelNumber)
    {
        return unlockedLevels.Contains(levelNumber); // Возвращаем, разблокирован ли уровень
    }

    public void CompleteLevel(int levelNumber)
    {
        // Добавьте здесь логику, которая должна выполняться при завершении уровня
        UnlockLevel(levelNumber + 1); // Разблокируем следующий уровень
    }
}