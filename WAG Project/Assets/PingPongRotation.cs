using UnityEngine;
using System.Collections;

public class PingPongRotation : MonoBehaviour {

    public float minRotation;
    public float maxRotation;
    public float duration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   float t = Mathf.PingPong(Time.time, duration) / duration;
       float newZ = Mathf.Lerp(minRotation, maxRotation, t);
       transform.rotation = Quaternion.Euler(0, 0, newZ);
	}
}
