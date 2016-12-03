using UnityEngine;
using System.Collections;

public class SetActiveOnGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameManager.Instance.OnStartGame += OnStart;
        gameObject.SetActive(false);
    }

    void OnStart()
    {
        if (this != null)
        {
            GameManager.Instance.OnStartGame -= OnStart;
            gameObject.SetActive(true);
        }
    }
}
