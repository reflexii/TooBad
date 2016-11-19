using UnityEngine;
using System.Collections;

public abstract class ClickAbleObject: MonoBehaviour 
{
	public virtual void Start()
	{
		transform.tag = "ClickAble";
	}

	public abstract void PerformClickAction (MouseHandler clickAction,int mouseButton);
	public abstract void PerformOnHoverAction (MouseHandler clickAction);
	public abstract void UndoOnHoverAction (MouseHandler clickActions);
}
