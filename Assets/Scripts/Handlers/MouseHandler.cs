using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

//Handles click actions.
public class MouseHandler : MonoBehaviour {
	public OnClickActions onClickActions;
	public OnHoverActions onHoverActions;
    public Player player;

	private ClickAbleObject currentObjectTarget;
	private ClickAbleUI currentUITarget;

	private PointerEventData cursor = new PointerEventData(EventSystem.current);
	private List<RaycastResult> objectsHit = new List<RaycastResult> ();

    private bool pointingClickAble;
    private bool pointingClickAbleUI;

    void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			UIRaycastClick ();
			MouseRaycastClick ();
            Attack();
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

        if (hit.collider != null)
        {
            if (hit.transform.tag == "ClickAble")
            {
                pointingClickAble = true;
                ClickAbleObject tmpTarget = hit.transform.GetComponent<ClickAbleObject>();

                if (tmpTarget != currentObjectTarget)
                {
                    if (currentObjectTarget != null)
                    {
                        UndoOnHoverAction();
                    }
                    currentObjectTarget = tmpTarget;
                    currentObjectTarget.PerformOnHoverAction(this);
                }
            }
            else
            {
                pointingClickAble = false;
                UndoOnHoverAction();
            }
        }
        else
        {
            pointingClickAble = false;
            UndoOnHoverAction();
        }
	}

	//Used at update. Only when mousebutton has been pressed.
	void MouseRaycastClick ()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

		if(hit.collider != null)
		{
			if (hit.transform.tag == "ClickAble") {
                pointingClickAble = true;
                ClickAbleObject tmpTarget = hit.transform.GetComponent<ClickAbleObject> ();
				UndoOnHoverAction ();
				tmpTarget.PerformClickAction (this);
			}
		}
        else
            pointingClickAble = false;
    }
		
	//Used at FixedUpdate.
	void UIRaycast()
	{
		cursor.position = Input.mousePosition;
		EventSystem.current.RaycastAll(cursor, objectsHit);
		if (objectsHit.Count != 0) {
			if (objectsHit [0].gameObject.tag == "ClickAbleUI") {
                pointingClickAbleUI = true;
                ClickAbleUI tmpTarget = objectsHit [0].gameObject.GetComponent<ClickAbleUI> ();
				if (tmpTarget != currentUITarget) {
					UndoOnHoverUIAction ();
					currentUITarget = tmpTarget;
					currentUITarget.PerformOnHoverAction (this);
				}
			} else {
                pointingClickAbleUI = false;
                UndoOnHoverUIAction ();
			}
		} else
        {
            pointingClickAbleUI = false;
            UndoOnHoverUIAction ();
		}
	}

	//Used at Update, only when mousebutton has been pressed.
	void UIRaycastClick()
	{
		cursor.position = Input.mousePosition;
		EventSystem.current.RaycastAll(cursor, objectsHit);
        if (objectsHit.Count != 0)
        {
            if (objectsHit[0].gameObject.tag == "ClickAbleUI")
            {
                pointingClickAbleUI = true;
                ClickAbleUI tmpTarget = objectsHit[0].gameObject.GetComponent<ClickAbleUI>();
                tmpTarget.PerformClickAction(this);
                UndoOnHoverUIAction();
            }
            else
            {
                pointingClickAbleUI = false;
            }
        }
        else
        {
            pointingClickAbleUI = false;
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

    void Attack()
    {
        if (!pointingClickAble && !pointingClickAbleUI)
        {
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.Attack(dir);

        }
    }
}
