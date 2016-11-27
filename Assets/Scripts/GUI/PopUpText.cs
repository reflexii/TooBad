using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public Text textComp;
    public float yOffset = 1f;
    public string positiveColorHex;
    public string negativeColorHex;

    private Transform _transform;

	void Update ()
    {
        if (textComp.color.a == 0)
        {
            DeActivate();
        }
	}

    public void SetPreferences(Vector3 position, string text, TextType negOrPos)
    {
        position.y += yOffset;
        transform.position = position;
        Color tmpColor = Color.blue;

        if (negOrPos == TextType.Positive)
        {
            ColorUtility.TryParseHtmlString("#"+positiveColorHex, out tmpColor);

        }
        else if (negOrPos == TextType.Negative)
        {
            ColorUtility.TryParseHtmlString("#"+negativeColorHex, out tmpColor);
        }

        textComp.color = tmpColor;
        textComp.text = text;
    }

    void DeActivate()
    {
        GameManager.Instance.objectPool.AddBackToPool(this);
    }

    public enum TextType
    {
        Negative,
        Positive
    }
}
