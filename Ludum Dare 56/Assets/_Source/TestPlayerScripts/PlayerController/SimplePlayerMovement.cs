using UnityEngine;

namespace _Source.TestPlayerScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimplePlayerMovement : MonoBehaviour
    {
        [field: Header("Player Stats")]
        [field: SerializeField]
        public float PlayerSpeed { get; private set; }

        [field: SerializeField] private float groundDrag;

        [field: Header("Ground Check")]
        [field: SerializeField]
        public float PlayerHeight { get; private set; }

        [field: SerializeField] public LayerMask GroundLayer { get; private set; }

        [field: Header("System Use")]
        [field: SerializeField]
        public Transform Orientation { get; private set; }

        private float _horizontalInput;

        private bool _isGrounded;

        private Vector3 _moveDirection;
        private Rigidbody _rb;

        private float _verticalInput;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        // Update is called once per frame
        private void Update()
        {
            _isGrounded = Physics.Raycast(
                transform.position,
                Vector3.down,
                PlayerHeight * 0.5f + 0.3f,
                GroundLayer);

            PlayerInput();
            SpeedControl();

            if (_isGrounded)
                _rb.drag = groundDrag;
            else
                _rb.drag = 0;
        }

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerInput()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }

        private void PlayerMove()
        {
            _moveDirection = Orientation.forward * _verticalInput +
                             Orientation.right * _horizontalInput;
            _rb.AddForce(_moveDirection * (PlayerSpeed * 5f), ForceMode.Force);
        }

        private void SpeedControl()
        {
            var flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude/2 > PlayerSpeed)
            {
                var limitedVel = flatVel.normalized * PlayerSpeed;
                _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
            }
        }
    }
}