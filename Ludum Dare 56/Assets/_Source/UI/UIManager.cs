using TMPro;
using UnityEngine;

namespace _Source.UI
{
    public class UIManager : MonoBehaviour
    {
        [field: SerializeField] public GameObject CollectedItemsWindow { get; private set; }
        [field: SerializeField] public GameObject WinWindow { get; private set; }
        
        private TextMeshProUGUI _textForItem;
        private TaskCount _taskCount;

        void OnEnable()
        {
            TaskCount.onChangeItemCount += ChangeItemsUI;
            GameManager.OnWin += ShowWinWindow;
        }

        void OnDisable()
        {
            TaskCount.onChangeItemCount -= ChangeItemsUI;
            GameManager.OnWin -= ShowWinWindow;
        }

        void Start()
        {
            _textForItem = CollectedItemsWindow.GetComponentInChildren<TextMeshProUGUI>();
        }

        void ChangeItemsUI(int items)
        {
            _textForItem.text = $"Собрано предметов: {items}/5";
        }

        void ShowWinWindow()
        {
            WinWindow.SetActive(true);
        }
    }
}