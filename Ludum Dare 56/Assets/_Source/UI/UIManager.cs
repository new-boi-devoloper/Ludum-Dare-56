using _Source.Utils;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.UI
{
    public class UIManager : MonoBehaviour
    {
        [field: SerializeField] public GameObject CollectedItemsWindow { get; private set; }
        [field: SerializeField] public GameObject WinWindow { get; private set; }
        [SerializeField] private float fadeDuration = 2.0f; // Длительность исчезновения

        private TextMeshProUGUI _textForItem;
        private TaskCount _taskCount;
        private CanvasGroup _winWindowCanvasGroup;

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

            // Получаем или добавляем компонент CanvasGroup к объекту WinWindow
            _winWindowCanvasGroup = WinWindow.GetComponent<CanvasGroup>();
            if (_winWindowCanvasGroup == null)
            {
                _winWindowCanvasGroup = WinWindow.AddComponent<CanvasGroup>();
            }

            // Изначально скрываем окно
            _winWindowCanvasGroup.alpha = 0f;
            WinWindow.SetActive(false);
        }

        void ChangeItemsUI(int items)
        {
            _textForItem.text = $"Собрано предметов: {items}/5";
        }

        void ShowWinWindow()
        {
            // Активируем окно
            WinWindow.SetActive(true);

            // Плавное исчезновение окна с использованием альфа-канала
            _winWindowCanvasGroup.DOFade(0f, fadeDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                // По завершении исчезновения переходим на другую сцену
                SceneChanger.ChangeScene("GameOverScene");
            });
        }
    }
}
