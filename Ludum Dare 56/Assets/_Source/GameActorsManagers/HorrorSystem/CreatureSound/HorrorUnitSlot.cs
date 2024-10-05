using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.CreatureSound
{
    public class HorrorUnitSlot : MonoBehaviour, IHorrorActivate
    {
        [field: SerializeField] public GameObject HorrorUnitPrefab { get; private set; }
        [field: SerializeField] private List<GameObject> pathPoints;

        public void ActivateHorror()
        {
            MoveUnit();
        }

        private void MoveUnit()
        {
            var unitRb = HorrorUnitPrefab.GetComponent<Rigidbody>();
            var path = pathPoints.ConvertAll(point => point.transform.position).ToArray();

            unitRb.DOPath(path, 5f, PathType.Linear, PathMode.Full3D);
        }
    }
}