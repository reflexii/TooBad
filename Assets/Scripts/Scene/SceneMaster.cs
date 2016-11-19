using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour {

	void Awake ()
    {
        if (!GameObject.FindGameObjectWithTag("Managers"))
        {
            StateManager.Instance.Init();
            StateManager.Instance.SwitchScene(StateManager.Instance.CurrentState(SceneManager.GetActiveScene().buildIndex));
        }
	}
	
}
