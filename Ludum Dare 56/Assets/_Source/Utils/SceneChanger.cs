using UnityEngine.SceneManagement;
namespace _Source.Utils
    
{
    public static class SceneChanger
    {
        public static void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}