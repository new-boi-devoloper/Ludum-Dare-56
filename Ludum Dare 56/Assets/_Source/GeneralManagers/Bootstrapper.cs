using _Source.PlayerScripts;
using _Source.TestPlayerScripts;
using UnityEngine;

namespace _Source.GeneralManagers
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private FixCameraPosition cameraPosition;
        private PlayerControls playerControls;

        private PlayerInvoker playerInvoker;
        private PlayerMovement playerMovement;

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