using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

//Handles click actions.
public class MouseHandler : MonoBehaviour {
	public OnClickActions onClickActions;
	public OnHoverActions onHoverActions;

	private ClickAbleObject currentObjectTarget;
	private ClickAbleUI currentUITarget;

	private PointerEventData cursor = new PointerEventData(EventSystem.current);
	private List<RaycastResult> objectsHit = new List<RaycastResult> ();

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			UIRaycastClick ();
			MouseRaycastClick ();
		}
	}

	void FixedUpdate () 
	{
		MouseRaycast ();
		UIRaycast ();
	}

	//Used at fixed update.
	void MouseRaycast ()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

		if(hit.collider != null)
		{
			if (hit.transform.tag == "ClickAble") {
				ClickAbleObject tmpTarget = hit.transform.GetComponent<ClickAbleObject> ();

				if (tmpTarget != currentObjectTarget) {
					if (currentObjectTarget != null) {
						UndoOnHoverAction ();
					}
					currentObjectTarget = tmpTarget;
					currentObjectTarget.PerformOnHoverAction (this);
				}
			} else
				UndoOnHoverAction ();
		} 
		else
			UndoOnHoverAction ();
	}

	//Used at update. Only when mousebutton has been pressed.
	void MouseRaycastClick ()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

		if(hit.collider != null)
		{
			if (hit.transform.tag == "ClickAble") {
				ClickAbleObject tmpTarget = hit.transform.GetComponent<ClickAbleObject> ();
				UndoOnHoverAction ();
				tmpTarget.PerformClickAction (this);
			}
		}
	}
		
	//Used at FixedUpdate.
	void UIRaycast()
	{
		cursor.position = Input.mousePosition;
		EventSystem.current.RaycastAll(cursor, objectsHit);
		if (objectsHit.Count != 0) {
			if (objectsHit [0].gameObject.tag == "ClickAbleUI") {
				ClickAbleUI tmpTarget = objectsHit [0].gameObject.GetComponent<ClickAbleUI> ();
				if (tmpTarget != currentUITarget) {
					UndoOnHoverUIAction ();
					currentUITarget = tmpTarget;
					currentUITarget.PerformOnHoverAction (this);
				}
			} else {
				UndoOnHoverUIAction ();
			}
		} else {
			UndoOnHoverUIAction ();
		}
	}

	//Used at Update, only when mousebutton has been pressed.
	void UIRaycastClick()
	{
		cursor.position = Input.mousePosition;
		EventSystem.current.RaycastAll(cursor, objectsHit);
		if (objectsHit.Count != 0) {
			if (objectsHit [0].gameObject.tag == "ClickAbleUI") {
				ClickAbleUI tmpTarget = objectsHit [0].gameObject.GetComponent<ClickAbleUI> ();
				tmpTarget.PerformClickAction (this);
				UndoOnHoverUIAction ();
			}
		} 
	}

	void UndoOnHoverAction ()
	{
		if (currentObjectTarget != null) {
			currentObjectTarget.UndoOnHoverAction (this);
			currentObjectTarget = null;
		}
	}

	void UndoOnHoverUIAction ()
	{
		if (currentUITarget != null) {
			currentUITarget.UndoOnHoverAction (this);
			currentUITarget = null;
		}
	}
}
