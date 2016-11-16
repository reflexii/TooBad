using UnityEngine;
using System.Collections;

namespace KanttuveiGame
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (GameObject.FindGameObjectWithTag(tag) != gameObject)
            {
                Destroy(gameObject);
            }
        }
    }
}