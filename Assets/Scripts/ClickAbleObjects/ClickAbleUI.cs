using UnityEngine;
using System.Collections;

public abstract class ClickAbleUI : MonoBehaviour 
{
	void Awake()
	{
		transform.tag = "ClickAbleUI";
	}

	public abstract void PerformClickAction (MouseHandler clickAction, int mouseButton);
	public abstract void PerformOnHoverAction (MouseHandler clickAction);
	public abstract void UndoOnHoverAction (MouseHandler clickAction);
}
