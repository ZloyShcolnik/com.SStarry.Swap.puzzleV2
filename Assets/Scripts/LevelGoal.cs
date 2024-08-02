using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[System.Serializable]
public class LevelGoal
{
    public int gemId; // ID кристалла
    public int targetCount; // Сколько нужно уничтожить
    public int currentCount = 0; // Сколько уже уничтожено

    public bool IsCompleted()
    {
        return currentCount >= targetCount; // Проверяем, выполнена ли цель
    }
}

