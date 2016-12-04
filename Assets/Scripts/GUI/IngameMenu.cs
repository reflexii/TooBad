using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class IngameMenu : MonoBehaviour
{
    public Button customButton;
    public Text header;
    //Set to true if player has died == you wont be able to leave the menu.
    public bool forcedMenu = false;

    public void OpenMenu(MenuState ms, bool forcedMenu)
    {
        this.forcedMenu = forcedMenu;

        gameObject.SetActive(!gameObject.activeSelf);

        if (!gameObject.activeSelf)
        {
            Time.timeScale = 1;
            return;
        }
        else
        {
            Time.timeScale = 0;

            if (ms == MenuState.RestartLevel)
            {
                UnityAction _ua = () => GameManager.Instance.dialogManager.confirmationDialog.SetConfirmationPreferences(DialogManager.TextKey.RestartConfirmation, GameManager.Instance.RestartCurrentLevel, "Restart");
                SetButtonPreferences(customButton, "Restart Level", _ua);
            }
            else if (ms == MenuState.RestartBoss)
            {
                UnityAction _ua = () => GameManager.Instance.dialogManager.confirmationDialog.SetConfirmationPreferences(DialogManager.TextKey.RestartConfirmation, GameManager.Instance.RestartCurrentLevel, "Restart");
                SetButtonPreferences(customButton, "Restart Fight", _ua);
            }
        }
    }

    public void DisplayHeader(DialogManager.TextKey textKey)
    {
        header.text = GameManager.Instance.dialogManager.GetText(textKey.ToString());
        header.gameObject.SetActive(true);
    }

    void SetButtonPreferences(Button button, string buttonName, UnityAction buttonAction)
    {
        button.GetComponentInChildren<Text>().text = buttonName;
        button.onClick.AddListener(buttonAction);
    }

    void OnDisable()
    {
        header.gameObject.SetActive(false);
    }

    public enum MenuState
    {
        RestartLevel,
        RestartBoss
    }
}
