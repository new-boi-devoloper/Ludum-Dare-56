using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskCount : MonoBehaviour
{
    [SerializeField] private List<Item> Item = new List<Item>();
    [SerializeField] private TMP_Text text;

    private int count;
    private void Update()
    {
        // if (Item[0].onAltar)
        // {
        //    count = 1;
        // }
        // if (Item[1].onAltar)
        // {
        //     count = 2;
        // }
        // if (Item[2].onAltar)
        // {
        //     count = 3;
        // }
        // text.text = $"Предметов в Алтаре {count}";
    }
}
