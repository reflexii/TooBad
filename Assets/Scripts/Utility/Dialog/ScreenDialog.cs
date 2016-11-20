using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenDialog : MonoBehaviour
{
    public Text dialogText;

    public bool playDialog;
    private string textToDisplay;
    private string currentText = "";
    private float timer;
    private float displaySpeed = 0.1f;
    private int i = 0;

    void Start()
    {
        GameManager.Instance.OnStartGame += OnStartGame;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(playDialog)
            PlayDialog();
    }

    void PlayDialog()
    {
        if (timer >= displaySpeed)
        {
            if (currentText.Length < textToDisplay.Length)
            {
                currentText += textToDisplay[i];
                dialogText.text = currentText;

                i++;
                timer = 0;
            }
            else
            {
                i = 0;
                playDialog = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void SetDialog(string text)
    {
        textToDisplay = text;
        playDialog = true;
    }

    void OnStartGame()
    {
        gameObject.SetActive(false);
    }
}
