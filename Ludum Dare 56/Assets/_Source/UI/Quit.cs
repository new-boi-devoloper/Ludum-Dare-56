using UnityEngine;

public class Quit : MonoBehaviour
{
    public void GameQuit()
    {
     Debug.Log("exited");
        Application.Quit();
    }
}