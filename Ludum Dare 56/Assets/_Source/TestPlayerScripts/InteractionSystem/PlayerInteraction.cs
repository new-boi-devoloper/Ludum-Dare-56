using System.Collections;
using System.Collections.Generic;
using _Source.TestPlayerScripts.InteractionSystem;
using UnityEngine;
using TMPro;
public class PlayerInteraction : MonoBehaviour, IInteractionController
{
    public Camera mainCam;
    [field: SerializeField] public float interactionDistance { get; private set; }

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IIteractable interactable = hit.collider.GetComponent<IIteractable>();

            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }

        interactionUI.SetActive(hitSomething);
    }

    public Item HeldItem { get; set; }
}
