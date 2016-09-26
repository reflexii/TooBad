using UnityEngine;
using System.Collections;

public abstract class ClickAbleObject: MonoBehaviour 
{
	void Awake()
	{
		transform.tag = "ClickAble";
	}

	public abstract void PerformClickAction (MouseHandler clickAction);
	public abstract void PerformOnHoverAction (MouseHandler clickAction);
	public abstract void UndoOnHoverAction (MouseHandler clickActions);
}
