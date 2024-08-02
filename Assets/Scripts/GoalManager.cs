using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using MatchThreeEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    public List<LevelGoal> levelGoals = new List<LevelGoal>();
    public int minGemId = 1; // Минимальный ID кристалла
    public int maxGemId = 10; // Максимальный ID кристалла
    public int minTargetCount = 5; // Минимальное количество для цели
    public int maxTargetCount = 15; // Максимальное количество для цели

    public List<Image> goalIcons=new List<Image>(); // Список изображений для целей
    public List<TextMeshProUGUI> goalCounters=new List<TextMeshProUGUI>(); // Список текстовых элементов для счетчиков
    
    public List<Image> goalIconsWin=new List<Image>(); // Список изображений для целей
    public List<TextMeshProUGUI> goalCountersWin=new List<TextMeshProUGUI>(); // Список текстовых элементов для счетчиков
    

    [SerializeField] 
    private List<TileTypeAsset> _tyleTypes=new List<TileTypeAsset>();
    
    [SerializeField]
    private GameObject _winScreen;

    void Start()
    {
        GenerateRandomGoals(); // Генерируем цели при запуске
        UpdateGoalUI();
    }

    public void UpdateGoalUI()
    {
        for (int i = 0; i < levelGoals.Count; i++)
        {
            if (i < goalIcons.Count && i < goalCounters.Count)
            {
                LevelGoal goal = levelGoals[i];

                // Установите иконку для цели
                goalIcons[i].sprite = GetGemSpriteById(goal.gemId);
                goalIconsWin[i].sprite = GetGemSpriteById(goal.gemId);

                // Обновите счетчик
                goalCounters[i].text = goal.currentCount + "/" + goal.targetCount;
                goalCountersWin[i].text = goal.currentCount + "/" + goal.targetCount;
            }
        }
    }

    private Sprite GetGemSpriteById(int gemId)
    {
       return _tyleTypes.Where(x => x.id == gemId).FirstOrDefault().sprite;
    }
    private void GenerateRandomGoals()
    {
        // Убедимся, что цели пусты перед началом
        levelGoals.Clear();

        // Создадим список возможных ID кристаллов
        List<int> availableGemIds = new List<int>();
        for (int i = minGemId; i <= maxGemId; i++)
        {
            availableGemIds.Add(i);
        }

        // Перемешаем список для случайного выбора
        ShuffleList(availableGemIds);

        // Выберем 3 случайных уникальных кристалла для целей
        for (int i = 0; i < 2; i++)
        {
            if (i < availableGemIds.Count)
            {
                int gemId = availableGemIds[i];
                int targetCount = Random.Range(minTargetCount, maxTargetCount + 1);

                // Создаем новую цель и добавляем ее в список
                LevelGoal newGoal = new LevelGoal
                {
                    gemId = gemId,
                    targetCount = targetCount,
                    currentCount = 0
                };

                levelGoals.Add(newGoal);
            }
        }
    }

    // Метод для перемешивания списка
    private void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public void UpdateGoal(int gemId)
    {
        foreach (LevelGoal goal in levelGoals)
        {
            if (goal.gemId == gemId && !goal.IsCompleted())
            {
                goal.currentCount++;
                UpdateGoalUI();
                if (AreAllGoalsCompleted())
                {
                    HandleTimeEnd();
                }
            }
        }
    }
    
    private void HandleTimeEnd()
    {
        _winScreen.SetActive(true);
        FindObjectOfType<Timer>().StopTimer();
        LevelProgressManager.Instance.CompleteLevel(LevelData.currentLevel);
    }
    
    public void HandleNextLevel()
    {
        LevelProgressManager.Instance.CompleteLevel(LevelData.currentLevel);
        SceneManager.LoadScene("PickLevelsScene");
    }

    public bool AreAllGoalsCompleted()
    {
        foreach (LevelGoal goal in levelGoals)
        {
            if (!goal.IsCompleted())
            {
                return false;
            }
        }
        return true;
    }
}
