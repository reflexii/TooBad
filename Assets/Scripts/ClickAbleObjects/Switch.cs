using UnityEngine;
using System.Collections;
using System;

public class Switch : ClickAbleObject
{
    public string name = "No Name";
    public InteractiveObject interactiveObject;

    public override void PerformClickAction(MouseHandler clickAction)
    {
        //Returns bool. You can perform action based on returned value. For example display info if interacting failed(Not having a key or something)
        interactiveObject.TakeAction();
    }

    public override void PerformOnHoverAction(MouseHandler clickActions)
    {
        clickActions.onHoverActions.DisplayOnHoverInfo(name);
    }

    public override void UndoOnHoverAction(MouseHandler clickActions)
    {
        clickActions.onHoverActions.HideOnHoverInfo();
    }
}
