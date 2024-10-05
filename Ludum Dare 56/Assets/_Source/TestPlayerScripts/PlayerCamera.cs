using UnityEngine;

namespace _Source.TestPlayerScripts
{
    public class PlayerCamera : MonoBehaviour
    {
        [field: Header("Camera Sensitivity")]
        [field: SerializeField]
        public float SensX { get; private set; }

        [field: SerializeField] public float SensY { get; private set; }

        [field: Header("System Use")]
        [field: SerializeField]
        public Transform Orientation { get; private set; } // TODO: Relocate To Bootstrapper

        private float _xRotation;

        private float _yRotation;

        private void Start()
        {
            LockCursor();
        }

        private void LateUpdate()
        {
            var mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
            var mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

            _yRotation += mouseX;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            Orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
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
    }
}