using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	void Start ()
    {
        GameManager.Instance.OnStartGame += StartGame;
	}

    public void StartGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.OnStartGame -= StartGame;
    }
	
}
