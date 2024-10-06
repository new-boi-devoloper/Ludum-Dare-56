using UnityEngine;

public class Door : MonoBehaviour, IIteractable
{
    public Animator mAnimator;
    public bool isOpen;

    private void Start()
    {
        if (isOpen)
            mAnimator.SetBool("IsOpen", true);
    }

    public string GetDescription()
    {
        if (isOpen) return "Press [E] to close";
        return "Press [E] to open";
    }

    public void Interact()
    {
        isOpen = !isOpen;
        if (isOpen)
            mAnimator.SetBool("IsOpen", true);
        else
            mAnimator.SetBool("IsOpen", false);
    }
}