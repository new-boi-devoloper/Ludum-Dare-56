using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string LoadSceneName;

    public void ButtonClicked()
    {
        SceneManager.LoadScene(LoadSceneName);
    }
}