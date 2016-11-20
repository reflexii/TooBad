using UnityEngine;
using System.Collections;

public class StartingPosition : MonoBehaviour {

	void Start ()
    {
        if (GameObject.FindWithTag("Player"))
        {
            GameObject.FindWithTag("Player").transform.position = transform.position;
        }
	}
	
}
