using UnityEngine;

namespace _Source.TestPlayerScripts.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class FootstepsSoundSystem : MonoBehaviour
    {
        [SerializeField] private float movementThreshold = 0.1f;

        private AudioSource _audioSource;
        private Vector3 _previousPosition;
        private bool _isMoving;

        private void Start()
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
            }

            if (_audioSource != null)
            {
                _audioSource.loop = true;
                _audioSource.Play();
            }

            _previousPosition = transform.position;
        }

        private void Update()
        {
            var currentPosition = transform.position;
            var movementDelta = Vector3.Distance(currentPosition, _previousPosition);

            if (movementDelta > movementThreshold)
            {
                if (!_isMoving)
                {
                    _isMoving = true;

                    _audioSource.Play();
                }
            }
            else
            {
                if (_isMoving)
                {
                    _isMoving = false;

                    _audioSource.Pause();
                }
            }

            _previousPosition = currentPosition;
        }
    }
}