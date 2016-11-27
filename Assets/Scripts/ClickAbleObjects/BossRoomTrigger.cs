using UnityEngine;
using System.Collections;

public class BossRoomTrigger : MonoBehaviour
{
    public InteractiveObject doorToClose;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            doorToClose.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("LightSettings").GetComponent<MasterLightSettings>().TurnLightsOnOrOff(true);

            Destroy(gameObject);
        }
    }
}
