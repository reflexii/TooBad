using UnityEngine;
using System.Collections;

public class SizeComparedToParent : MonoBehaviour {
	public float widthMultiplier;
	public float heightMultiplier;

	void Awake()
	{
		RectTransform parentRt = transform.parent.GetComponent<RectTransform> ();
		float width = parentRt.rect.width;
		float height = parentRt.rect.height;
		GetComponent<RectTransform>().sizeDelta = new Vector2( width * widthMultiplier, height * heightMultiplier);

		if(transform.childCount != 0)
			transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2( width * widthMultiplier, height * heightMultiplier);
	}
}
