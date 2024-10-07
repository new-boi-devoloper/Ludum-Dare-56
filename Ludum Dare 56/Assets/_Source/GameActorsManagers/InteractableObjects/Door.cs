using DG.Tweening;
using UnityEngine;

namespace _Source.GameActorsManagers.InteractableObjects
{
    public class Door : MonoBehaviour, IIteractable
    {
        [SerializeField] private Transform doorParent; // Родительский объект, который будет поворачиваться
        [SerializeField] private float openAngle = 90f; // Угол открытия двери
        [SerializeField] private float openDuration = 1f; // Длительность открытия/закрытия двери

        private bool _isOpen;
        private Vector3 _initialRotation;

        private void Start()
        {
            // Сохраняем начальное вращение двери
            _initialRotation = doorParent.localEulerAngles;
        }

        public string GetDescription()
        {
            return _isOpen ? "Press [E] to close" : "Press [E] to open";
        }

        public void Interact()
        {
            _isOpen = !_isOpen;
            RotateDoor(_isOpen);
        }

        private void RotateDoor(bool open)
        {
            float targetAngle = open ? openAngle : 0f;
            doorParent.DOLocalRotate(new Vector3(_initialRotation.x, _initialRotation.y + targetAngle, _initialRotation.z), openDuration)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    if (!open)
                    {
                        // Возвращаем дверь в исходное положение
                        doorParent.localEulerAngles = _initialRotation;
                    }
                });
        }
    }
}