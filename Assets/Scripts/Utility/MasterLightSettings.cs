using UnityEngine;
using System.Collections;

public class MasterLightSettings : MonoBehaviour {

    public Light directionalLight;
    public Light candleLight;

    public bool tunrLightsOffOnPlay;

	void Start ()
    {
        candleLight = GameObject.Find("CandleLight").GetComponent<Light>();
        if (tunrLightsOffOnPlay)
        {
            candleLight.enabled = true;

            if(directionalLight != null)
                directionalLight.enabled = false;
        }
        else
        {
            candleLight.enabled = false;
            directionalLight.enabled = true;
        }
	}

    public void TurnLightsOnOrOff(bool turnOn)
    {
        if (turnOn)
        {
            candleLight.enabled = false;
            directionalLight.enabled = true;
        }
        else if(!turnOn)
        {
            candleLight.enabled = true;
            directionalLight.enabled = false;
        }
    }
}
