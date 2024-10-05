using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem.SoundHorror
{
    public class HorrorSoundSlot : MonoBehaviour, IHorrorActivate
    {
        [field:SerializeField] public AudioSource HorrorSound { get; private set; }

        public void ActivateHorror()
        {
            HorrorSound.Play();
        }
    }
}