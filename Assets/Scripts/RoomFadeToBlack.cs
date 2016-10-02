using UnityEngine;
using System.Collections;

public class RoomFadeToBlack : MonoBehaviour {

    public GameObject fadeToBlackObject;
    public SpriteRenderer Srenderer;
    public float fadeToBlackDuration;

    private Transform _transform;
    private float lerpValue = 0f;
    private bool fadeToBlackTriggered = false;
    private Color firstColor = new Color(0f, 0f, 0f, 1f);
    private Color secondColor = new Color(0f, 0f, 0f, 0f);
    private bool fadeOut = true;
    

	// Use this for initialization
	void Awake () {
        _transform = GetComponent<Transform>();
        Srenderer = fadeToBlackObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (fadeToBlackTriggered) {
            fadeToBlack();
        }
	}

    void OnTriggerExit2D(Collider2D col) {
        Debug.Log("Triggered");
        fadeToBlackTriggered = true;
        
    }

    private void fadeToBlack() {
        Srenderer.color = Color.Lerp(firstColor, secondColor, lerpValue);
        if (lerpValue < 1f) {
            lerpValue += Time.deltaTime / fadeToBlackDuration;
        }
        if (lerpValue >= 1f) {
            switchColors();
            lerpValue = 0f;
            fadeOut = !fadeOut;
            fadeToBlackTriggered = false;
            
        }
    }

    private void switchColors() {
        if (fadeOut) {
            firstColor = new Color(0f, 0f, 0f, 0f);
            secondColor = new Color(0f, 0f, 0f, 1f);
        } else {
            firstColor = new Color(0f, 0f, 0f, 1f);
            secondColor = new Color(0f, 0f, 0f, 0f);
        }
        
    }
}
