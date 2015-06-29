using UnityEngine;
using System.Collections;

public class EscapeToQuit : MonoBehaviour
{
    private void Awake() {

    }

    private void Start() {

    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
