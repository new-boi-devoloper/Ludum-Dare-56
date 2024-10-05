using _Source.Camera;
using UnityEngine;

namespace _Source.PlayerScripts
{
    public class PlayerInvoker
    {
        private PlayerMovement _playerMovement;
        private Player _player;
        private FixCameraPosition _cameraPosition;

        public PlayerInvoker(Player player, FixCameraPosition cameraPosition, PlayerMovement playerMovement)
        {
            _player = player;
            _cameraPosition = cameraPosition;
            _playerMovement = playerMovement;
        }

        public void HandleMouseInput(float mouseY, float mouseX)
        {
            InvokeRotate(mouseY, mouseX);
        }

        private void InvokeJump()
        {
            _playerMovement.Jump(_player.JumpForce, _player.Rb);
        }

        private void InvokeMove(Vector3 direction)
        {
            _playerMovement.Move(_player.PlayerSpeed, _player.Rb, direction);
        }

        private void InvokeRotate(float rotationY, float rotationX)
        {
            _playerMovement.Rotate(rotationY, rotationX, _player.orientaion, _cameraPosition.transform);
        }
    }
}