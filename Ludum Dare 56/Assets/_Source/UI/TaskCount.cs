using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TaskCount : MonoBehaviour
{
    public static event Action<int> onChangeItemCount; 
    
    private int itemPlacedCount = 0; // Счетчик размещенных предметов
    
    private void OnEnable()
    {
        // Подписываемся на событие OnItemPlaced
        AltarSlot.OnItemPlaced += IncrementItemPlacedCount;
    }

    private void OnDisable()
    {
        // Отписываемся от события при деактивации объекта
        AltarSlot.OnItemPlaced -= IncrementItemPlacedCount;
    }

    // Метод, вызываемый при размещении предмета
    private void IncrementItemPlacedCount()
    {
        itemPlacedCount++; // Увеличиваем счетчик
        onChangeItemCount?.Invoke(itemPlacedCount);
    }
}
