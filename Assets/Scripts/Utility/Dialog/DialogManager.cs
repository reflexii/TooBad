using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public TextAsset textFile;
    public DialogBox dialogBox;
    private Dictionary<string, string> texts = new Dictionary<string, string>();

    void Awake()
    {
        CreateDictionary();
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

    public void DisplayDialog(TextKey textKey)
    {
        string textToDisplay = "NULL";

        if (texts[textKey.ToString()] != null)
           textToDisplay = texts[textKey.ToString()];

        dialogBox.gameObject.SetActive(true);
        dialogBox.SetDialog(textToDisplay);
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
        Tutorial3
    }
}
