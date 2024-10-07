using UnityEngine;

public class GameContinue : MonoBehaviour
{
    [SerializeField] private FirstPersonController firstPerson;

    public void Continue()
    {
        firstPerson.cameraCanMove = true;
        firstPerson.lockCursor = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        firstPerson.playerCanMove = true;
        firstPerson.enableHeadBob = true;
    }
}