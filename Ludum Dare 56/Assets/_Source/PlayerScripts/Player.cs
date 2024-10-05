using UnityEngine;

namespace _Source.PlayerScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [field: Header("Player Stats")]
        [field: SerializeField]
        public float JumpForce { get; private set; }

        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public float PlayerRotation { get; private set; }


        [field: Header("Player Toys")]
        [field: SerializeField]
        public Transform orientaion { get; private set; }

        public bool IsGrounded { get; private set; }
        public Rigidbody Rb { get; private set; }

        private void Start()
        {
            Rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) IsGrounded = false;
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) IsGrounded = true;
        }
    }
}