using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAwayScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void SwitchScene()
    {
        SceneChanger.ChangeScene(sceneName);
    }

    private void OnEnable()
    {
        GameManager.OnWin += SwitchScene;
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }
}
