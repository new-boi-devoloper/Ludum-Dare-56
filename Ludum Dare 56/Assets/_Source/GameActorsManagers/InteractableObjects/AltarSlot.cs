using System.Collections;
using System.Collections.Generic;
using _Source.TestPlayerScripts.InteractionSystem;
using UnityEngine;

public class AltarSlot : MonoBehaviour, IIteractable
{
    public bool Occupied { get; private set; }
    private IInteractionController interactionController;
    
    public void Initialize(IInteractionController interactionController)
    {
        this.interactionController = interactionController;
    }

    public void Interact()
    {
        if (!Occupied && interactionController.HeldItem != null)
        {
            PlaceItem(interactionController.HeldItem);
        }
    }

    public string GetDescription()
    {
        return Occupied ? "Slot is occupied" : "Place item here";
    }

    private void PlaceItem(Item item)
    {
        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
        item.SetHeld(false);
        item.SetInteractable(false); // Отключаем взаимодействие с предметом после размещения
        Occupied = true;
        interactionController.HeldItem = null;
    }
}
