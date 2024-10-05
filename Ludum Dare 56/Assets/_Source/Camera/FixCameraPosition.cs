using UnityEngine;

namespace _Source.Camera
{
    public class FixCameraPosition : MonoBehaviour
    {
        [field: SerializeField] public Transform _cameraPosition { get; private set; }

        // Update is called once per frame
        void Update()
        {
            transform.position = _cameraPosition.position;
        }
    }
}
