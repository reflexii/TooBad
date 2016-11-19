using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    void Awake()
    {
        GameManager.Instance.OnLevelLoad += StartGame;
    }

    void OnDestroy()
    {
        GameManager.Instance.OnLevelLoad -= StartGame;
    }

    public void StartGame()
    {
        GameManager.Instance.OnLevelLoad -= StartGame;
        GetComponent<CameraController>().enabled = true;
    }
}
