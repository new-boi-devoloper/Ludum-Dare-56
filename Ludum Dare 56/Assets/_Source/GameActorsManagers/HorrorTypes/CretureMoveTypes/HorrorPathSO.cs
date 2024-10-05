using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHorrorPath", menuName = "Horror/Path", order = 1)]
public class HorrorPathSO : ScriptableObject
{
    public Vector3[] waypoints;
    public float duration = 1f;
    public PathType pathType = PathType.Linear;
    public PathMode pathMode = PathMode.Full3D;
    public int resolution = 10;
    public Color gizmoColor = Color.red;
}