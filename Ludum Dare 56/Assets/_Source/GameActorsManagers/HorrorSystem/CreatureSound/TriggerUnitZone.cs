using _Source.Utils;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.CreatureSound
{
    public class TriggerUnitZone : MonoBehaviour
    {
        private GameObject SpawnObject;

        private void Start()
        {
            SpawnObject = GetComponentInChildren<GameObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject)) ;
            {
                var horrorSlot = SpawnObject.GetComponent<HorrorUnitSlot>();
                horrorSlot.ActivateHorror();
            }
        }
    }
}