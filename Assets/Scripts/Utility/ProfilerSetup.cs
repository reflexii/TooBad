using UnityEngine;
using System.Collections;

public class ProfilerSetup : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Profiler.maxNumberOfSamplesPerFrame = -1;
    }
}
