using UnityEngine;
using System.Collections;

public class ConstrainPosition : MonoBehaviour
{
    private enum PositionMode
    {
        Global, Local //, Offset // todo: change offset... editor with handles
    }

    [SerializeField] private PositionMode positionMode = PositionMode.Local;
    [SerializeField] private Vector3 minPosition;
    [SerializeField] private Vector3 maxPosition;

    private static readonly Color gizmoColorSelected = new Color(1f, 0.3f, 0.4f);
    private static readonly Color gizmoColorDefault = new Color(0.6f, 0.2f, 0.2f);

    private Vector3 size {
        get { return maxPosition - minPosition; }
    }

    private Vector3 worldCenter {
        get {
            Vector3 providedCenter = (maxPosition + minPosition) / 2f;
            return (positionMode == PositionMode.Global ?
                    providedCenter : transform.TransformPoint(providedCenter) - transform.localPosition);
        }
    }

    private void Awake() {

    }

    private void Start() {

    }

    private void Update() {

    }

    private void LateUpdate() {
        Vector3 position = (positionMode == PositionMode.Global ?
                            transform.position : transform.localPosition);

        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);
        position.z = Mathf.Clamp(position.z, minPosition.z, maxPosition.z);

        if (positionMode == PositionMode.Global) {
            transform.position = position;
        } else {
            transform.localPosition = position;
        }
    }

    public void OnDrawGizmos() {
        Gizmos.color = gizmoColorDefault;
        Gizmos.DrawWireCube(worldCenter, size);
    }

    public void OnDrawGizmosSelected() {
        Gizmos.color = gizmoColorSelected;
        Gizmos.DrawWireCube(worldCenter, size);
    }
}
