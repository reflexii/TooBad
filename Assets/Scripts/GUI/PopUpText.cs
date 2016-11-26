using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public float yOffset = 1f;
    private Transform _transform;
    private Text _text;

	void Start ()
    {
	}

	void Update ()
    {
        if (GetComponentInChildren<Text>().color.a == 0)
        {
            DeActivate();
        }
	}

    public void SetPreferences(Vector3 position, string text)
    {
        position.y += yOffset;
        transform.position = position;
        GetComponentInChildren<Text>().text = text;
    }

    void DeActivate()
    {
        GameManager.Instance.objectPool.AddBackToPool(this);
    }
}
