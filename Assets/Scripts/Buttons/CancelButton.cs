using UnityEngine;
using System.Collections;
using System;

public class CancelButton : MyButton {

    protected override void OnClickFunction()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
