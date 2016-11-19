using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotHandler : MonoBehaviour {
	public GameObject highlight;

	private GameObject currentlyActiveSlot;

	public void HighlightSlot(GameObject go, float size)
	{
		//Change this method!
		highlight.SetActive (true);
		float offset = (highlight.GetComponent<RectTransform> ().rect.width - size) / 2;
		highlight.transform.localPosition = new Vector3(go.transform.localPosition.x + offset, highlight.transform.localPosition.y, highlight.transform.localPosition.z);
		currentlyActiveSlot = go;
	}

	public void CancelHighlight(GameObject go)
	{
		if (go != currentlyActiveSlot)
			return;
		highlight.SetActive (false);
		currentlyActiveSlot = null;
	}
}
