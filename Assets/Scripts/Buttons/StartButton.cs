using UnityEngine;
using System.Collections;
using System;

public class StartButton : MyButton
{
    protected override void OnClickFunction()
    {
        GameManager.Instance.StartGame();
    }
}
