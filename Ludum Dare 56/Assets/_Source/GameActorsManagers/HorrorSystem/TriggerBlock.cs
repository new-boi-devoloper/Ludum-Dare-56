using _Source.Utils;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem
{
    public class TriggerBlock : MonoBehaviour, ITriggerZone
    {
        [field: SerializeField] public int ZoneID { get; private set; }
        public Vector3 ZonePosition => transform.position;
        public Vector3 HorrorSpawn => GetHorrorSpawnPoint();

        public void OnTriggerEnter(Collider other)
        {
            if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject))
            {
                TriggerEventManager.TriggerZone(ZoneID, ZonePosition, HorrorSpawn);
            }
        }

        private Vector3 GetHorrorSpawnPoint()
        {
            var spawnPoint = GetComponentInChildren<HorrorSpawnPoint>();
            
            spawnPoint.ActivateHorror();
            return spawnPoint != null ? spawnPoint.Position : Vector3.zero;
        }
    }
}