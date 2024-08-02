 using UnityEngine;
using UnityEngine.UI; // Для работы с UI
using TMPro; // Для работы с TextMesh Pro

public class LevelButton : MonoBehaviour
{
    public int levelNumber; // Номер уровня, который представляет эта кнопка
    private LevelProgressManager progressManager; // Ссылка на менеджер прогресса
    private Button button; // Ссылка на саму кнопку
    private Image buttonBackground; // Фон кнопки
  //  private TextMeshProUGUI buttonText; // Текст внутри кнопки
    public Color lockedColor = new Color(1, 1, 1, 0.5f); // Цвет для заблокированной кнопки (полупрозрачный)
    public Color unlockedColor = new Color(1, 1, 1, 1f);
    private LevelSelector _levelSelector;// Цвет для разблокированной кнопки

    void Awake()
    {
        button = GetComponent<Button>(); // Получаем кнопку
        buttonBackground = GetComponent<Image>(); // Получаем фон кнопки (обычно это компонент Image)


        progressManager = FindObjectOfType<LevelProgressManager>();
        _levelSelector = FindObjectOfType<LevelSelector>();
    }

    void Start()
    {
        if (progressManager != null && button != null)
        {
            bool isUnlocked = progressManager.IsLevelUnlocked(levelNumber); // Проверяем, разблокирован ли уровень
            button.interactable = isUnlocked; // Устанавливаем возможность интерактивности кнопки
            
            // Изменяем прозрачность в зависимости от состояния кнопки
            if (buttonBackground != null)
            {
                buttonBackground.color = isUnlocked ? unlockedColor : lockedColor; // Меняем цвет фона
            }
            
           

            if (isUnlocked)
            {
                button.onClick.AddListener(LoadLevel); // Добавляем обработчик нажатия, если уровень разблокирован
            }
        }
    }

    private void LoadLevel()
    {
        _levelSelector.SelectLevel(levelNumber);
    }
}
