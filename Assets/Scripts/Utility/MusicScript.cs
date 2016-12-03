using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    public float targetVolume = 0.3f;
    private AudioSource audioS;
    public float fadeInInSeconds = 10f;
    private float fastFadeInOut = 2f;
    private float volumeAdded;
    private bool bossMusicSequence = false;

    public AudioClip menuMusic;
    public AudioClip ingameMusic;
    public AudioClip bossMusic;

	// Use this for initialization
	void Start () {

        if (audioS == null)
        {
            audioS = GetComponent<AudioSource>();
        }

        volumeAdded = targetVolume / fadeInInSeconds;
        audioS.Play();
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

    //This is called each time after the scene has been loaded.
    public void SetMusic(State.SceneID sid)
    {
        if (audioS == null)
        {
            audioS = GetComponent<AudioSource>();
        }  
           
        setOrLoadClip(sid);
        resetClip();
    }

    //The audioclip is loaded from the resources only once. Not each time you change/reset a scene.
    void setOrLoadClip(State.SceneID sid)
    {

        if (sid == State.SceneID.LevelOne)
        {
            if (ingameMusic == null)
            {
                ingameMusic = Resources.Load("Music/InGameMusic") as AudioClip;
            }

            audioS.clip = ingameMusic;
        }
        else if (sid == State.SceneID.MainMenu)
        {
            if (menuMusic == null)
            {
                menuMusic = Resources.Load("Music/InForest") as AudioClip;
            }

            audioS.clip = menuMusic;
        }
    }

    void resetClip()
    {
        audioS.volume = 0.0f;
        audioS.Stop();
        audioS.Play();
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
