using UnityEngine;
using System.Collections;

public class SetInactiveOnLoad : MonoBehaviour {

    void Awake()
    {
        GameManager.Instance.OnLevelLoad += Activate;
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnLevelLoad -= Activate;
    }

    void Activate()
    {
        GameManager.Instance.OnLevelLoad -= Activate;
        gameObject.SetActive(false);
    }
}
