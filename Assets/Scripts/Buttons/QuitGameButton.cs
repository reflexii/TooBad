﻿using UnityEngine;
using System.Collections;
using System;

public class QuitGameButton : MyButton
{
    protected override void OnClickFunction()
    {
        GameManager.Instance.dialogManager.confirmationDialog.SetConfirmationPreferences(DialogManager.TextKey.Dialog1, OnClick, "Quit");
    }

    void OnClick()
    {
        Application.Quit();
    }
}