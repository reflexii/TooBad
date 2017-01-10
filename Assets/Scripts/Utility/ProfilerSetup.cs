using UnityEngine;
using System.Collections;
using UnityEngine.Profiling;

public class ProfilerSetup : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Profiler.maxNumberOfSamplesPerFrame = -1;
    }
}
