using UnityEngine;
using System.Collections;

public class SetActiveOnGame : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        GameManager.Instance.OnStartGame += OnStart;
        GameManager.Instance.OnLevelLoad += OnLevel;

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

    void OnLevel()
    {
        if (this != null)
        {
            GameManager.Instance.OnLevelLoad -= OnLevel;
            gameObject.SetActive(true);
        }
    }
}
