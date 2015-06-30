using UnityEngine;
using System.Collections;

public class PingPongIntensity : MonoBehaviour {

    public float low;
    public float high;
    public float duration;

    private Light m_Light;

	// Use this for initialization
	void Start () {
	   m_Light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	   float t = Mathf.PingPong(Time.time, duration);
       m_Light.intensity = Mathf.Lerp(low, high, t);
	}
}
