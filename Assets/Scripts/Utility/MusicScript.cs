using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    public float targetVolume = 0.3f;
    private AudioSource audioS;
    public float fadeInInSeconds = 10f;
    private float fastFadeInOut = 2f;
    private float volumeAdded;
    private bool bossMusicSequence = false;

    public AudioClip ingameMusic;
    public AudioClip bossMusic;

	// Use this for initialization
	void Start () {
        audioS = GetComponent<AudioSource>();
        volumeAdded = targetVolume / fadeInInSeconds;
        if (ingameMusic != null) {
            audioS.clip = ingameMusic;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (audioS.volume < targetVolume && !bossMusicSequence) {
            fadeInMusic();
        }
        if (bossMusicSequence) {
            if (audioS.volume > 0f) {
                fadeOutMusic();
            } else {
                audioS.clip = bossMusic;
                audioS.Play();
                bossMusicSequence = false;
            }
        }
	}

    public void fadeInMusic() {
        audioS.volume += volumeAdded * Time.deltaTime;
    }

    public void fadeOutMusic() {
        audioS.volume -= (targetVolume / fastFadeInOut) * Time.deltaTime;
    }

    public void changeToBossMusic() {
        bossMusicSequence = true;
    }
}
