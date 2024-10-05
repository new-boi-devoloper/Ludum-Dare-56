using UnityEngine;

namespace _Source.GameActorsManagers.HorrorTypes
{
    public class HorrorSound : MonoBehaviour, IHorror
    {
        [field:SerializeField] public AudioSource horrorSound { get; private set; }

        public void PlayHorror()
        {
            horrorSound.Play();
        }
    }
}