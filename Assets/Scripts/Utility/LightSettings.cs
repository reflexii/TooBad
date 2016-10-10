using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightSettings : MonoBehaviour
{
    [SerializeField]
    private bool SetupOne;
    [SerializeField]
    private bool SetupTwo;
    [SerializeField]
    private List<float> rangeValues;
    [SerializeField]
    private List<float> intensityValues;

    void Start()
    {
        Light light = GetComponent<Light>();
        if (SetupOne)
        {
            light.range = rangeValues[0];
            light.intensity = intensityValues[0];
        }
        else if (SetupTwo)
        {
            light.range = rangeValues[1];
            light.intensity = intensityValues[1];
        }
    }
}
