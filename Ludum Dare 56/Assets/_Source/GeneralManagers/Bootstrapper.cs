using _Source.Camera;
using _Source.PlayerScripts;
using UnityEngine;

namespace _Source.GeneralManagers
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private FixCameraPosition cameraPosition;

        private PlayerInvoker playerInvoker;
        private PlayerMovement playerMovement;
        private PlayerControls playerControls;

        private void Awake()
        {
            // Инициализация компонентов
            playerMovement = new PlayerMovement();
            playerInvoker = new PlayerInvoker(player, cameraPosition, playerMovement);
            playerControls = new PlayerControls();

            // Связывание компонентов
            inputListener.Initialize(playerInvoker, playerControls);
        }
    }
}