using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.SoundHorror
{
    public class HorrorSoundSlot : MonoBehaviour, IHorrorActivate
    {
        [field: SerializeField] public string horrorSoundToPlay { get; private set; }

        public void ActivateHorror()
        {
            AudioManager.instance.Play(horrorSoundToPlay);
        }
    }
}