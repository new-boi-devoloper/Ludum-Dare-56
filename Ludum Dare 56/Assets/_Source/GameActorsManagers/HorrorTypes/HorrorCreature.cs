using UnityEngine;
using DG.Tweening;

namespace _Source.GameActorsManagers.HorrorTypes
{
    [RequireComponent(typeof(Rigidbody))]
    public class HorrorCreature : MonoBehaviour, IHorror
    {
        [field: SerializeField] public HorrorPathSO HorrorPathSoSo { get; private set; }
        private Rigidbody _playerRb;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
        }

        public void PlayHorror()
        {
            CreatureMove();
        }

        private void CreatureMove()
        {
            _playerRb.DOPath(HorrorPathSoSo.waypoints, HorrorPathSoSo.duration, HorrorPathSoSo.pathType, HorrorPathSoSo.pathMode, HorrorPathSoSo.resolution, HorrorPathSoSo.gizmoColor)
                .SetEase(Ease.Linear)
                .OnComplete(() => Debug.Log("Horror path completed"));
        }
    }
}