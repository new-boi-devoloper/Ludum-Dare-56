using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.CreatureSound
{
    public class HorrorUnitSlot : MonoBehaviour, IHorrorActivate
    {
        [field: SerializeField] public GameObject HorrorUnitPrefab { get; private set; }
        [field: SerializeField] private float timeForRun;
        [field: SerializeField] private List<GameObject> pathPoints;

        public void ActivateHorror()
        {
            MoveUnit();
        }

        private void MoveUnit()
        {
            var copiedUnit = Instantiate(HorrorUnitPrefab);
            var unitRb = copiedUnit.GetComponent<Rigidbody>();
            var path = pathPoints.ConvertAll(point => point.transform.position).ToArray();

            unitRb.DOPath(path, timeForRun, PathType.Linear, PathMode.Full3D)
                .OnComplete(() => Destroy(copiedUnit)); // Уничтожаем copiedUnit по завершении пути
        }
    }
}