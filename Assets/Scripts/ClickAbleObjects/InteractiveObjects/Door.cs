using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Door : InteractiveObject
{
    public List<KeyItem.KeyItemType> reqKeys;

    public override bool TakeAction()
    {
        List<KeyItem> keyItems = new List<KeyItem>();

        if (reqKeys.Count != 0)
        {
            int count = 0;

            foreach (KeyItem.KeyItemType keyType in reqKeys)
            {
                if (GameManager.Instance.inventory.ContainsKeyItemOfType(keyType) != null)
                {
                    keyItems.Add(GameManager.Instance.inventory.ContainsKeyItemOfType(keyType));
                    count++;
                }
            }

            if (count != reqKeys.Count)
            {
                return false;
            }
        }

        gameObject.SetActive(!gameObject.activeSelf);

        foreach (KeyItem k in keyItems)
        {
            //TODO: Change this if more keyItemsSlots are added.
            GameManager.Instance.inventory.actionBar.keyItemSlot.RemoveItem();
        }

        return true;
    }
}
