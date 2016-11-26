using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnHoverActions : MonoBehaviour {
	
	public GameObject onHoverInfo;
	public bool dragging;

	private GameObject currentlyActiveSlot;
	private bool hovering = false;

	void Update()
	{
		if (hovering) {
			if (!dragging)
				onHoverInfo.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0.3f, 0.6f, 1f);
			else
				HideOnHoverInfo ();
		}
	}

	public void DisplayOnHoverInfo(Item item)
	{
		onHoverInfo.SetActive (true);
		hovering = true;
		onHoverInfo.GetComponentInChildren<Text> ().text = item.itemName;
	}

    public void DisplayOnHoverInfo(string toDisplay)
    {
        onHoverInfo.SetActive(true);
        hovering = true;
        onHoverInfo.GetComponentInChildren<Text>().text = toDisplay;
    }

    public void HideOnHoverInfo()
	{
		onHoverInfo.SetActive (false);
		hovering = false;
	}		
}
