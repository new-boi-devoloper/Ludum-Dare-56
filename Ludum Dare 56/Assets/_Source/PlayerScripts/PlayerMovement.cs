using UnityEngine;

namespace _Source.PlayerScripts
{
    public class PlayerMovement
    {
        private float _yRotation;
        private float _xRotation;

        public void Jump(float jumpForce, Rigidbody playerRb)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public void Move(float playerSpeed, Rigidbody playerRb, Vector3 direction)
        {
            playerRb.MovePosition(playerRb.position + direction * (playerSpeed * Time.deltaTime));
        }

        public void Rotate(float mouseY, float mouseX, Transform playerOrientation, Transform cameraPosition)
        {
            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            cameraPosition.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            playerOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}