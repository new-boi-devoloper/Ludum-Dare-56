using System;
using _Source.GameActorsManagers.HorrorSystem.SoundHorror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace _Source.TestPlayerScripts
{
    public class FootstepsSoundSystem : MonoBehaviour
    {
        private Vector3 _previousPosition;
        private AudioSource _audioSource;
        private bool _isMoving;

        private void Start()
        {
            // Инициализация предыдущего положения
            _previousPosition = transform.position;
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            CheckSteps();
        }

        private void CheckSteps()
        {
            if (transform.position != _previousPosition)
            {
                _isMoving = true;
                PlayStepSound();
                _previousPosition = transform.position;
            }
            else
            {
                _isMoving = false;
                StopStepSound();
            }
        }

        private void PlayStepSound()
        {
            _audioSource.enabled = true;
        }

        private void StopStepSound()
        {
            _audioSource.enabled = false;
        }
    }
}