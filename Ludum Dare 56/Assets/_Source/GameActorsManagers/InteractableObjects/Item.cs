using System;
using _Source.TestPlayerScripts.InteractionSystem;
using UnityEngine;

public class Item : MonoBehaviour, IIteractable
{
    [SerializeField] private string name;
    [SerializeField] private Transform pointForItem;
    [SerializeField] private float rotationAngle;

    private bool isHeld = false;
    private bool isInteractable = true;
    private IInteractionController interactionController;

    public void Initialize(IInteractionController interactionController)
    {
        this.interactionController = interactionController;
    }
    

    private void Update()
    {
        if (isHeld && pointForItem != null)
        {
            transform.position = pointForItem.position;
            transform.rotation = pointForItem.rotation;
        }
    }

    public void Interact()
    {
        if (!isHeld && isInteractable && interactionController.HeldItem == null)
        {
            PickUpItem();
        }
    }

    public string GetDescription()
    {
        return isInteractable ? $"{name} get" : $"{name} is placed";
    }

    private void PickUpItem()
    {
        interactionController.HeldItem = this;
        SetHeld(true);
    }

    public void SetHeld(bool held)
    {
        isHeld = held;
        gameObject.SetActive(true); // Убедитесь, что предмет всегда активен
    }

    public void SetInteractable(bool interactable)
    {
        isInteractable = interactable;
    }
}