using UnityEngine;
using System.Collections;

public class SceneTrigger : MonoBehaviour
{
    public State.SceneID sceneToActivate;

    void OnTriggerEnter2D(Collider2D col)
    {
        StateManager.Instance.SwitchScene(sceneToActivate);
        Destroy(gameObject);
    }
}
