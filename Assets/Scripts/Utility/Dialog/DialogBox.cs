using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {
    public Text dialogText;
	
	void Update ()
    {
        transform.position = GameManager.Instance.player.transform.position + new Vector3(-1.5f,2,0);
    }

    public void SetDialog(string text)
    {
        transform.position = GameManager.Instance.player.transform.position + new Vector3(-1.5f, 2, 0);
        dialogText.text = text;
    }
}
