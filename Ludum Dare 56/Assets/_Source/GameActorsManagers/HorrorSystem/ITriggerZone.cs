using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem
{
    public interface ITriggerZone
    {
        int ZoneID { get; }
        Vector3 ZonePosition { get; }
        Vector3 HorrorSpawn { get; }
        void OnTriggerEnter(Collider other);
    }
}