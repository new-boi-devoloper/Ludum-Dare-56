using _Source.PlayerScripts;
using _Source.TestPlayerScripts;
using UnityEngine;

namespace _Source.GeneralManagers
{
    public class Bootstrapper : MonoBehaviour
    {
        public PlayerInteraction playerInteraction;
        public AltarSlot[] altarSlots;
        public Item[] items;

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