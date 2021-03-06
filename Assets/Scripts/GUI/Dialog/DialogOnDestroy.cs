﻿using UnityEngine;
using System.Collections;

public class DialogOnDestroy : MonoBehaviour
{
    public DialogManager.TextKey displayOnDestroy;

    void Start()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.dialogManager.HideDialog();
    }

    void OnDestroy()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.dialogManager.DisplayDialog(displayOnDestroy);
    }
}
