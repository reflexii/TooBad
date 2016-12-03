using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossRoomTrigger : MonoBehaviour
{
    public InteractiveObject doorToClose;
    public GameObject musicObject;
    public GameObject bossLight;
    public float wantedLightIntensity;
    private bool lightSeq = false;
    private bool readyToDestroy = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            doorToClose.gameObject.SetActive(true);
            //GameObject.FindGameObjectWithTag("LightSettings").GetComponent<MasterLightSettings>().TurnLightsOnOrOff(true);
            GameManager.Instance.soundManager.musicPlayer.changeToBossMusic();

            startLightSequence();
            
        }
    }

    public void startLightSequence() {
        lightSeq = true;
    }

    public void Update() {
        if (lightSeq) {
           if (bossLight.GetComponent<Light>().intensity < wantedLightIntensity) {
                bossLight.GetComponent<Light>().intensity += 2 * Time.deltaTime;
            } else {
                readyToDestroy = true;
            }
        }

        if (readyToDestroy) {
            Destroy(gameObject);
        }

    }
}
