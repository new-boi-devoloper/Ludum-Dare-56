using UnityEngine;

namespace _Source.TestPlayerScripts
{
    public class FixCameraPosition : MonoBehaviour
    {
        [field: SerializeField] public Transform CameraPosition { get; private set; }

        // Update is called once per frame
        private void LateUpdate()
        {
            transform.position = CameraPosition.position;
        }
    }
}