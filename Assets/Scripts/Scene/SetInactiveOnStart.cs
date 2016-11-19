using UnityEngine;
using System.Collections;

//This is used by objects which are not needed on main menu. Activated when playable level is loaded.
public class SetInactiveOnStart : MonoBehaviour {

	void Awake ()
    {
        GameManager.Instance.OnLevelLoad += Activate;
        gameObject.SetActive(false);
	}

    void OnDestroy()
    {
        GameManager.Instance.OnLevelLoad -= Activate;
    }

    void Activate()
    {
        GameManager.Instance.OnLevelLoad -= Activate;
        gameObject.SetActive(true);
    }
}
