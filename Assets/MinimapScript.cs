using UnityEngine;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    private Camera minimapCamera;
    private Shader unlitShader;

	// Use this for initialization
	void Start () {
        minimapCamera = GetComponent<Camera>();
        unlitShader = Shader.Find("Sprites/Default");
        minimapCamera.SetReplacementShader(unlitShader, "");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
