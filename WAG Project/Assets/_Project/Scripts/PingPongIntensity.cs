using UnityEngine;
using System.Collections;

public class PingPongIntensity : MonoBehaviour {

    public float low;
    public float high;
    public float duration;
    public bool randomDuration;

    private Light m_Light;
    private float m_duration;

    // Use this for initialization
    void Start () {
        m_Light = GetComponent<Light>();
        m_duration = duration;
        if (randomDuration) {
            m_duration = Random.value * duration + 0.1f;
        }
    }
    
    // Update is called once per frame
    void Update () {
        float t = Mathf.PingPong(Time.time, m_duration);
        m_Light.intensity = Mathf.Lerp(low, high, t);
    }
}
