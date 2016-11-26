using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour
{
    public DialogManager.TextKey textKey;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.Instance.dialogManager.DisplayDialog(textKey);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameManager.Instance.dialogManager.HideDialog();
    }
}
