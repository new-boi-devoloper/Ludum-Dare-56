using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem
{
    public class HorrorManager : MonoBehaviour
    {
        private void OnEnable()
        {
            TriggerEventManager.OnZoneEntered += HandleZoneEntered;
        }

        private void OnDisable()
        {
            TriggerEventManager.OnZoneEntered -= HandleZoneEntered;
        }

        private void HandleZoneEntered(int zoneID, Vector3 zonePosition, Vector3 horrorSpawnPosition)
        {
            //Final Point of spawning horrorPrefab
            Debug.Log($"Player entered zone {zoneID} at position {zonePosition}");
            Debug.Log($"Horror spawn point at {horrorSpawnPosition}");
            // Дополнительная логика спавна источника ужаса
        }
    }
}