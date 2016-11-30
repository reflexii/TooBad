using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ConfirmationDialog : MonoBehaviour
{
    public Button cancelButton;
    public Button confirmationButton;
    public Text dialogText;
    public delegate void ConfirmationAction();

    private UnityAction _confirmationAction;

    public void SetConfirmationPreferences(DialogManager.TextKey textKey, ConfirmationAction callback = null, string buttonName = null)
    {
        gameObject.SetActive(true);
        confirmationButton.GetComponentInChildren<Text>().text = buttonName;
        dialogText.text = GameManager.Instance.dialogManager.GetText(textKey.ToString());
        _confirmationAction = () => CloseDialog(callback);
        confirmationButton.onClick.AddListener(_confirmationAction);
    }

    public void CloseDialog(ConfirmationAction action = null)
    {
        if (action != null)
        {
            action();
        }

        gameObject.SetActive(false);
    }
}
