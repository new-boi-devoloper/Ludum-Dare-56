using _Source.PlayerScripts;
using _Source.TestPlayerScripts;
using _Source.UI;
using UnityEngine;

namespace _Source.GeneralManagers
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerInteraction playerInteraction;
        [SerializeField] private AltarSlot[] altarSlots;
        [SerializeField] private Item[] items;
        void Awake()
        {
            foreach (var altarSlot in altarSlots)
            {
                altarSlot.Initialize(playerInteraction);
            }

            foreach (var item in items)
            {
                item.Initialize(playerInteraction);
            }
        }
        
    }
}