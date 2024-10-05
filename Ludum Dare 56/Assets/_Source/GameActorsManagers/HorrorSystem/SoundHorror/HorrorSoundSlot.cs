using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.SoundHorror
{
    public class HorrorSoundSlot : MonoBehaviour, IHorrorActivate
    {
        public void ActivateHorror()
        {
            AudioManager.instance.Play("Steps");
        }
    }
}