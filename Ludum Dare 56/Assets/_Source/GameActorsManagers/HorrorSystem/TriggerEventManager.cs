using System;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem
{
    public static class TriggerEventManager
    {
        public static event Action<int, Vector3, Vector3> OnZoneEntered;

        public static void TriggerZone(int zoneID, Vector3 triggerBlockPosition, Vector3 horrorSpawnPosition)
        {
            OnZoneEntered?.Invoke(zoneID, triggerBlockPosition, horrorSpawnPosition);
        }
    }
}