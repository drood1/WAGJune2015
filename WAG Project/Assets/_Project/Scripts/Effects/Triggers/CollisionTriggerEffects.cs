using UnityEngine;
using System.Collections;

public class CollisionTriggerEffects : TriggerEffects
{
    // Variables to specify in the editor.
    [Tooltip("Leave empty to trigger on any tag.")]
    [SerializeField] protected string testColliderTag;

    [SerializeField] private bool triggerOnStay = false;

    protected override void Awake() {
        base.Awake();
    }

    private void Start() {

    }

    private void Update() {

    }

    // 3D Collision
    private void OnCollisionEnter(Collision collision) {
        StartEventIfMatch(collision.collider.gameObject);
    }

    public void OnCollisionStay(Collision other) {
        if (triggerOnStay) {
            StartEventIfMatch(other.gameObject);
        }
    }

    // 3D Trigger
    private void OnTriggerEnter(Collider other) {
        StartEventIfMatch(other.gameObject);
    }

    public void OnTriggerStay(Collider other) {
        if (triggerOnStay) {
            StartEventIfMatch(other.gameObject);
        }
    }

    // 2D Collision
    public void OnCollisionEnter2D(Collision2D collision) {
        StartEventIfMatch(collision.collider.gameObject);
    }

    public void OnCollisionStay2D(Collision2D other) {
        if (triggerOnStay) {
            StartEventIfMatch(other.gameObject);
        }
    }

    // 2D Trigger
    public void OnTriggerEnter2D(Collider2D other) {
        StartEventIfMatch(other.gameObject);
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (triggerOnStay) {
            StartEventIfMatch(other.gameObject);
        }

    }

    protected virtual void StartEventIfMatch(GameObject collisionObject) {
        if (testColliderTag.Length == 0 || collisionObject.tag.Equals(testColliderTag)) {
            StartEvent();
        }
    }
}
