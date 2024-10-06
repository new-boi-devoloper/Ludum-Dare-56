using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject Pause;
    [SerializeField] private FirstPersonController firstPerson;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            firstPerson.cameraCanMove = false;
            firstPerson.lockCursor = false;
            Pause.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}
