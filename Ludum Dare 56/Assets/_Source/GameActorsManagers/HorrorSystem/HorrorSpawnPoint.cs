using _Source.GameActorsManagers.HorrorTypes;
using UnityEngine;

namespace _Source.GameActorsManagers.HorrorSystem
{
    public class HorrorSpawnPoint : MonoBehaviour
    {
        [field: SerializeField] public GameObject horrorPrefab { get; private set; }
        public Vector3 Position => transform.position;

        private IHorror _horror;

        private void Start()
        {
            CreateHorror();
        }

        private void CreateHorror()
        {
            var horrorInstance = Instantiate(horrorPrefab, Position, Quaternion.identity);
            
            _horror = horrorInstance.GetComponent<IHorror>();
            if (_horror == null)
            {
                Debug.LogError("Horror prefab does not implement IHorror interface.");
            }
        }

        public void ActivateHorror()
        {
            _horror?.PlayHorror();
        }
    }
}