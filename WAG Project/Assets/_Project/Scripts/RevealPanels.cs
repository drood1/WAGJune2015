using UnityEngine;
using System.Collections;

public class RevealPanels : MonoBehaviour
{
    [SerializeField] private float fadeInTime = 1f;
    [SerializeField] private Interpolate.EaseType easeType = Interpolate.EaseType.EaseInOutQuad;

    private SpriteRenderer[] panelRenderers;
    private int currentPanel;
    private Interpolate.Function easeFunction;

    private static readonly Color transparent = new Color(1f, 1f, 1f, 0f);

    private void Awake() {
        panelRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        currentPanel = 0;
        easeFunction = Interpolate.Ease(easeType);

        // Set all panels to start transparent.
        foreach (SpriteRenderer panelRenderer in panelRenderers) {
            panelRenderer.color = transparent;
        }
    }

    private void Start() {

    }

    private void Update() {
        // Reveal panels sequentially.
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentPanel < panelRenderers.Length) {
                StartCoroutine(RevealPanel(panelRenderers[currentPanel]));
                currentPanel++;
            }
        }
    }

    private IEnumerator RevealPanel(SpriteRenderer panelRenderer) {
        // Coroutine fades a single panel in using the specified easing function and fadeInTime.
        float startTime = Time.time;

        Color color = transparent;
        panelRenderer.color = color;

        while (Time.time - startTime < fadeInTime) {
            color.a = easeFunction(0f, 1f, Time.time - startTime, fadeInTime);
            panelRenderer.color = color;
            yield return null;
        }

        panelRenderer.color = Color.white; // Ensure we end with pure white.
    }
}
