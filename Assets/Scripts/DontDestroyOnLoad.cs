using UnityEngine;
using System.Collections;

    public class DontDestroyOnLoad : MonoBehaviour
    {

    public bool dontDestroyOnReload = false; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(!dontDestroyOnReload)
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