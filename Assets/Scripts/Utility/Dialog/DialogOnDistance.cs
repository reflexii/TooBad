using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogOnDistance : MonoBehaviour {

    public List<DialogManager.TextKey> textKeys = new List<DialogManager.TextKey>();
    public List<float> triggerDistance = new List<float>();

    private Transform player;
    private bool dialogEnabled;

	void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	void Update ()
    {
        for(int i = 0; i < triggerDistance.Count; i++)
        {
            float distance = triggerDistance[triggerDistance.Count - 1 - i];

            if (Vector3.Distance(transform.position, player.position) <= distance)
            {
                GameManager.Instance.dialogManager.DisplayDialog(textKeys[triggerDistance.Count - 1 - i]);
                dialogEnabled = true;
                return;
            }
        }

        if (dialogEnabled)
        {
            GameManager.Instance.dialogManager.HideDialog();
            dialogEnabled = false;
        }
    }
}
