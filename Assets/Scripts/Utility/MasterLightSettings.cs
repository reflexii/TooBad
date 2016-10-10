using UnityEngine;
using System.Collections;

public class MasterLightSettings : MonoBehaviour {

    public Light directionalLight;
    public Light candleLight;

    public bool tunrLightsOffOnPlay;

	void Start ()
    {
        if (tunrLightsOffOnPlay)
        {
            candleLight.enabled = true;
            directionalLight.enabled = false;
        }
        else
        {
            candleLight.enabled = false;
            directionalLight.enabled = true;
        }
	}

}
