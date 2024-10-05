using UnityEngine;

namespace _Source.PlayerScripts
{
    public class InputListener : MonoBehaviour
    {
        [field: SerializeField] public float SensX { get; private set; }
        [field: SerializeField] public float SensY { get; private set; }

        private PlayerInvoker _playerInvoker;
        private PlayerControls _playerControls;

        public void Initialize(PlayerInvoker playerInvoker, PlayerControls playerControls)
        {
            _playerInvoker = playerInvoker;
            _playerControls = playerControls;
            LockCursor();
        }

        private static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private static void UnLockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Update()
        {
            GetInputValues();
            HorizontalMouseMove();
            VerticalMouseMove();
        }

        private float HorizontalMouseMove()
        {
            var mouseInputHorizontal = _playerControls.Player.Look.ReadValue<Vector2>().y * Time.deltaTime * SensY;
            return mouseInputHorizontal;
        }

        private float VerticalMouseMove()
        {
            var mouseInputVertical = _playerControls.Player.Look.ReadValue<Vector2>().x * Time.deltaTime * SensX;
            return mouseInputVertical;
        }

        void GetInputValues()
        {
            _playerInvoker.HandleMouseInput(HorizontalMouseMove(), VerticalMouseMove());
        }
    }
}