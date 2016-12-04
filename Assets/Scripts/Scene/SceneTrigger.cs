using UnityEngine;
using System.Collections;

public class SceneTrigger : MonoBehaviour
{
    public State.SceneID sceneToActivate;

    void OnTriggerEnter2D(Collider2D col)
    {
        //StateManager.Instance.SwitchScene(sceneToActivate);
        GameManager.Instance.eventManager.StartEvent(EventManager.Event.Prologue,DialogManager.TextKey.Dialog1_0);
        Destroy(gameObject);
    }
}
