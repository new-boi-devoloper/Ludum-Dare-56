using _Source.Utils;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.CreatureSound
{
    public class TriggerUnitZone : MonoBehaviour
    {
        private HorrorUnitSlot _horrorUnitSlot;

        private void Start()
        {
            // Ищем дочерний объект с компонентом HorrorUnitSlot
            _horrorUnitSlot = GetComponentInChildren<HorrorUnitSlot>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject)) ;
            {
                _horrorUnitSlot.ActivateHorror();
            }
        }
    }
}