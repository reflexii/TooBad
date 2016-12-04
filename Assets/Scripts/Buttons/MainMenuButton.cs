using UnityEngine;
using System.Collections;
using System;

public class MainMenuButton : MyButton
{
    protected override void OnClickFunction()
    {
        GameManager.Instance.dialogManager.confirmationDialog.SetConfirmationPreferences(DialogManager.TextKey.BackToMenuConfirmation, OnClick, "Main Menu");
    }

    void OnClick()
    {
        GameManager.Instance.ReloadObjects();
        StateManager.Instance.SwitchScene(State.SceneID.MainMenu);
    }
}
