using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.CreatureSound
{
    public class HorrorUnitSlot : MonoBehaviour, IHorrorActivate
    {
        [field: SerializeField] public AnimType UnitAnimType { get; private set; }
        [field: SerializeField] public GameObject HorrorUnitPrefab { get; private set; }
        [field: SerializeField] private float timeForRun;
        [field: SerializeField] private List<GameObject> pathPoints;

        public void ActivateHorror()
        {
            MoveUnit();
        }

        private void MoveUnit()
        {
            var path = pathPoints.ConvertAll(point => point.transform.position).ToArray();
            var copiedUnit = Instantiate(HorrorUnitPrefab, path[0], Quaternion.identity);
            var unitRb = copiedUnit.GetComponent<Rigidbody>();
            
            ChooseAnim(copiedUnit);
            
            unitRb.DOPath(path, timeForRun, PathType.Linear, PathMode.Full3D)
                .OnComplete(() => Destroy(copiedUnit));
        }

        private void ChooseAnim(GameObject copiedUnit)
        {
            var unitAnim = copiedUnit.GetComponent<Animator>();
            if (UnitAnimType == AnimType.Run)
            {
                unitAnim.SetBool("Run", true);
            }

            if (UnitAnimType == AnimType.AngryReaction)
            {
                unitAnim.SetBool("AngryReaction", true);
            }
        }

        public enum AnimType
        {
            Run,
            AngryReaction
        }
    }
}