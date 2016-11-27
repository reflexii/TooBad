using UnityEngine;
using System.Collections;

public class DialogOnKeyPress : MonoBehaviour
{
    public DialogManager.TextKey textKey;
    public KeyCode inputKey;
    public bool inventoryRelated;

	void Update ()
    {
        if (Input.GetKeyUp(inputKey))
        {
            if (inventoryRelated)
            {
                foreach (SlotScipt s in GameManager.Instance.inventory.actionBar.itemSlots)
                {
                    if (s.inputKey == inputKey && s.GetItem() != null)
                    {
                        GameManager.Instance.dialogManager.DisplayDialog(textKey);
                        Destroy(gameObject);
                    }
                }
            }
        }
	}
}
