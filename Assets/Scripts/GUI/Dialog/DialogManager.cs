using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public TextAsset textFile;
    public DialogBox dialogBox;
    public ScreenDialog screenDialog;
    public int maxWordLength = 8;
    public int maxCharLehght = 60;

    private List<string> dialogsOnHold = new List<string>();
    private Dictionary<string, string> texts = new Dictionary<string, string>();

    void Awake()
    {
        CreateDictionary();
    }

    void Start()
    {
        dialogsOnHold.Clear();
    }

    void CreateDictionary()
    {
        string[] textLines = textFile.text.Split('\n');
        string[][] pairs = new string[textLines.Length][];

        for (int i = 0; i < textLines.Length; i++)
            pairs[i] = textLines[i].Split('=');

        for (int i = 0; i < pairs.Length; i++)
            texts.Add(pairs[i][0], pairs[i][1]);
    }

    void SliceAndPlayDialog(string[] textLines)
    {
        string tmp = "";

        for (int i = 0; i < textLines.Length; i++)
        {
            tmp += textLines[i];
            tmp += " ";

            //Cuts the sentences based on defined limits.
            if (i != 0 && i % maxWordLength == 0 && tmp.Length >= maxCharLehght || i == textLines.Length - 1 || tmp.Length >= maxCharLehght)
            {
                dialogsOnHold.Add(tmp);
                tmp = "";
            }
        }

        NextDialog();
    }

    public void DisplayDialog(TextKey textKey)
    {

        if (dialogsOnHold.Count == 0)
        {
            string textToDisplay = "NULL";

            if (texts[textKey.ToString()] != null)
            {
                textToDisplay = texts[textKey.ToString()];
                string[] words = textToDisplay.Split(' ');

                if (words.Length > maxWordLength)
                {
                    SliceAndPlayDialog(words);
                    return;
                }
            }

            if (dialogBox != null)
            {
                dialogBox.gameObject.SetActive(true);
                dialogBox.SetDialog(textToDisplay);
                return;
            }
        }
    }

    public void DisplayScreenDialog(TextKey textKey)
    {
        string textToDisplay = GetText(textKey.ToString());
        screenDialog.gameObject.SetActive(true);
        screenDialog.SetDialog(textToDisplay);

    }

    public void NextDialog()
    {
        if (dialogsOnHold.Count != 0)
        {
            DisplayDialog(dialogsOnHold[0]);
            dialogsOnHold.RemoveAt(0);
        }
        else
        {
            dialogBox.gameObject.SetActive(false);
        }
    }

    //If you want to print plain text. Use of GetText() is recommended before calling this method to keep up the localization.
    public void DisplayDialog(string text)
    {
        dialogBox.gameObject.SetActive(true);
        dialogBox.SetDialog(text);
    }

    //used by for example items. The name of class as string is used as "key".
    public string GetText(string key)
    {
        if (texts[key] != null)
            return texts[key];

        Debug.Log("PLEASE ADD '" + key + "' into dialog.txt");

        return key;
    }

    public void HideDialog()
    {
        dialogBox.gameObject.SetActive(false);
    }

    public enum TextKey
    {
        None,
        Tutorial1,
        Tutorial2,
        Tutorial3,
        Tutorial4,
        Tutorial5,
        Tutorial6,
        Tutorial7,
        Dialog1
    }
}
