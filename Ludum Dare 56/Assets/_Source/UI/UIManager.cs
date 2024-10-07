using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI
{
    public class UIManager: MonoBehaviour
    {
        [field:SerializeField] public GameObject ItemCount { get; private set; }
        private TextMeshProUGUI textforitem;

        private TaskCount _taskCount;

        void OnEnable()
        {
            TaskCount.onChangeItemCount += ChangeItemsUI;
        }

        void OnDisable()
        {
            TaskCount.onChangeItemCount -= ChangeItemsUI;
        }

        void Start()
        {
            textforitem = ItemCount.GetComponentInChildren<TextMeshProUGUI>();
        }


        void ChangeItemsUI(int items)
        { 
            textforitem.text = $"Собрано предметов: {items}/5";
        }
    }
}