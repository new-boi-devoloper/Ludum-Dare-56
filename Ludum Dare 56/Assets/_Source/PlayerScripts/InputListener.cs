using UnityEngine;

namespace _Source.PlayerScripts
{
    public class InputListener : MonoBehaviour
    {
        [field: SerializeField] public float SensX { get; private set; }
        [field: SerializeField] public float SensY { get; private set; }
        private PlayerControls _playerControls;

        private PlayerInvoker _playerInvoker;

        private void Update()
        {
            GetInputValues();
            HorizontalMouseMove();
            VerticalMouseMove();
        }

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

        private void GetInputValues()
        {
            _playerInvoker.HandleMouseInput(HorizontalMouseMove(), VerticalMouseMove());
        }
    }
}