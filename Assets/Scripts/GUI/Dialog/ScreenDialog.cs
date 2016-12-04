using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenDialog : MonoBehaviour
{
    public Text dialogText;
    public GameObject keyToContinue;
    public float displaySpeed = 0.02f;

    public bool playDialog;
    private string textToDisplay;
    private string currentText = "";
    private float timer;
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
                keyToContinue.SetActive(true);
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
        currentText = "";
        i = 0;
        playDialog = true;
        keyToContinue.SetActive(false);
    }

    void OnStartGame()
    {
        gameObject.SetActive(false);
    }
}
