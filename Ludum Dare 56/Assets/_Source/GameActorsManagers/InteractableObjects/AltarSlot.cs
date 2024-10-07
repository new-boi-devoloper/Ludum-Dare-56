using System.Collections;
using System.Collections.Generic;
using System;
using _Source.TestPlayerScripts.InteractionSystem;
using UnityEngine;

public class AltarSlot : MonoBehaviour, IIteractable
{
     public static event Action OnItemPlaced; // Событие, вызываемое при размещении предмета
    
        public bool Occupied { get; private set; } // Свойство, указывающее, занят ли слот
    
        private IInteractionController interactionController;
    
        // Инициализация контроллера взаимодействия
        public void Initialize(IInteractionController interactionController)
        {
            this.interactionController = interactionController;
        }
    
        // Метод взаимодействия с объектом
        public void Interact()
        {
            if (!Occupied && interactionController.HeldItem != null)
            {
                PlaceItem(interactionController.HeldItem);
            }
        }
    
        // Получение описания слота
        public string GetDescription()
        {
            return Occupied ? "Slot is occupied" : "Place item here";
        }
    
        // Метод размещения предмета в слоте
        private void PlaceItem(Item item)
        {
            // Установка позиции и вращения предмета
            item.transform.position = transform.position;
            item.transform.rotation = transform.rotation;
    
            // Обновление состояния предмета
            item.SetHeld(false);
            item.SetInteractable(false); // Отключаем взаимодействие с предметом после размещения
            
            Occupied = true; // Обозначаем слот как занятый
            interactionController.HeldItem = null; // Убираем удерживаемый предмет
    
            // Вызываем событие OnItemPlaced
            OnItemPlaced?.Invoke();
        }
}
