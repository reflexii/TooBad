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
                        return;
                    }
                }

                if (inputKey == GameManager.Instance.inventory.actionBar.consumableSlot.inputKey && GameManager.Instance.inventory.actionBar.consumableSlot.GetItem() != null)
                {
                    GameManager.Instance.eventManager.StartEvent(EventManager.Event.Hallucination, DialogManager.TextKey.None);
                    Destroy(gameObject);
                    return;
                }
            }
        }
	}
}
