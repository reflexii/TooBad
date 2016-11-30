using UnityEngine;
using System.Collections;

    public class DontDestroyOnLoad : MonoBehaviour
    {
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameManager.Instance.OnRestart += DestroyOnRestart;
        if (GameObject.FindGameObjectWithTag(tag) != gameObject)
        {
            Destroy(gameObject);
        }
    }

    void DestroyOnRestart()
    {
        if(this != null)
            Destroy(gameObject);
    }
}