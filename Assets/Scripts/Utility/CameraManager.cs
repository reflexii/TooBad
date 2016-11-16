using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnStartGame += StartGame;
    }

    public void StartGame()
    {
        GetComponent<CameraController>().enabled = true;
    }
}
