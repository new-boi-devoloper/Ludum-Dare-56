using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnWin;

    private void OnEnable()
    {
        TaskCount.onChangeItemCount += ChangeItemCount;
    }

    private void OnDisable()
    {
        TaskCount.onChangeItemCount += ChangeItemCount;
    }

    private void ChangeItemCount(int items)
    {
        if (items == 5)
        {
            OnWin?.Invoke();
        }
    }
}