using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {
    public Text dialogText;
	
    void Start()
    {
        GameManager.Instance.OnStartGame += OnStartGame;
        gameObject.SetActive(false);
    }

	void Update ()
    {
        transform.position = GameManager.Instance.player.transform.position + new Vector3(-1.5f,2,0);
    }

    public void SetDialog(string text)
    {
        if (GameManager.Instance != null)
        {
            transform.position = GameManager.Instance.player.transform.position + new Vector3(-1.5f, 2, 0);
            dialogText.text = text;
        }
    }

    void OnStartGame()
    {
        gameObject.SetActive(false);
    }
}
