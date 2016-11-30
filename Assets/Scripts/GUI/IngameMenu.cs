using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class IngameMenu : MonoBehaviour
{
    public Button customButton; 

    public void OpenMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        if (!gameObject.activeSelf)
        {
            Time.timeScale = 1;
            return;
        }
        else
        {
            Time.timeScale = 0;

            UnityAction _ua = () => GameManager.Instance.dialogManager.confirmationDialog.SetConfirmationPreferences(DialogManager.TextKey.Tutorial1, GameManager.Instance.RestartCurrentLevel, "Restart");
            SetButtonPreferences(customButton, "Restart Level", _ua);
        }
    }

    void SetButtonPreferences(Button button, string buttonName, UnityAction buttonAction)
    {
        button.GetComponentInChildren<Text>().text = buttonName;
        button.onClick.AddListener(buttonAction);
    }
}
