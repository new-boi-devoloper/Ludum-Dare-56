using UnityEngine;
using UnityEngine.Serialization;

public class CameraShake : MonoBehaviour
{
    [Header("Configuration")]
    
    [SerializeField] private bool enable = true;
    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;
    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform cameraHolder = null;

    private Vector3 _previousPosition;
    private Vector3 _startPos;

    private void Awake()
    {
        _startPos = _camera.localPosition;
        _previousPosition = transform.position;
    }

    public void UpdateShake()
    {
        if (!enable) return;
        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private void CheckMotion()
    {
        if (transform.position != _previousPosition)
        {
            PlayMotion(FootStepMotion());
        }

        _previousPosition = transform.position;
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y,
            transform.position.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }
}