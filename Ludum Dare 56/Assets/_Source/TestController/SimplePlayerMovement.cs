using System;
using _Source.Utils;
using UnityEngine;

namespace _Source.TestController
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimplePlayerMovement : MonoBehaviour
    {
        [field: Header("Player Stats")]
        [field: SerializeField] public float PlayerSpeed { get; private set; }

        [field: Header("Ground Check")]
        [field: SerializeField] public float PlayerHeight { get; private set; }
        [field: SerializeField] public LayerMask GroundLayer { get; private set; }

        [field: Header("System Use")]
        [field: SerializeField] public Transform Orientation { get; private set; }

        private Rigidbody _rb;
        private Vector3 _moveDirection;

        private float _horizontalInput;
        private float _verticalInput;

        private bool _isGrounded;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerInput();
        }

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void OnCollisionStay(Collision other)
        {
            if (LayerMaskCheck.ContainsLayer(GroundLayer, other.gameObject))
            {
                _isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (LayerMaskCheck.ContainsLayer(GroundLayer, other.gameObject))
            {
                _isGrounded = false;
            }
        }

        private void PlayerInput()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }

        private void PlayerMove()
        {
            _moveDirection = (Orientation.forward * _verticalInput) +
                             (Orientation.right * _horizontalInput);
            _rb.AddForce(_moveDirection * PlayerSpeed, ForceMode.Force);
        }
    }
}