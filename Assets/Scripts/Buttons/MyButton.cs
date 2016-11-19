using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour
{
    Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { OnClickFunction(); });
    }

    protected abstract void OnClickFunction();
}
