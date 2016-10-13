﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public GameObject slotPrefab;
	public LootHandler lootHandler;

	private List<SlotScipt> itemSlots = new List<SlotScipt>();
	private float xOffset;
	private float yOffset;
	private int slotRows;
	private int slotCols;


	void Awake () 
	{
		RectTransform inventoryRt = gameObject.GetComponent<Image> ().GetComponent<RectTransform> ();
		RectTransform slotRt = slotPrefab.GetComponent<Image> ().GetComponent<RectTransform> ();

		//Calculates how many rows and cols of slots can fit, based on the size of the inventory "image".
		slotRows = (int)(inventoryRt.rect.width / slotRt.rect.width) - 1;
		slotCols = (int)(inventoryRt.rect.height / slotRt.rect.height) - 1;
		//Calculates balanced offsets for the slots.
		xOffset = (inventoryRt.rect.width - (slotRt.rect.width * slotRows)) / (slotRows +1);
		yOffset = (inventoryRt.rect.height - (slotRt.rect.height * slotCols)) / (slotCols+1);

		CreateSlots (inventoryRt.rect.width ,inventoryRt.rect.height ,slotRt.rect.width,slotRt.rect.height);
		gameObject.SetActive (false);
	}
		
	void CreateSlots (float invWidth, float invHeight,float slotWidth, float slotHeight)
	{
		Vector3 pos = new Vector3(invWidth * -1  + slotWidth, invHeight - slotHeight,0);
		Vector3 origPos = pos;
		pos.y = pos.y  - yOffset;
		pos.x = pos.x  + xOffset;

		for (int i = 0 ; i < slotCols; i++) {
			for (int k = 0; k < slotRows; k++) {
				if (k != 0)
					pos.x = pos.x + slotWidth + xOffset;
				GameObject o = (GameObject) Instantiate (slotPrefab, pos, Quaternion.identity);
				o.transform.SetParent (gameObject.transform, false);
				SlotScipt s = o.GetComponent<SlotScipt> ();
				s.slotNumber = i + k;
				itemSlots.Add(s);
			}

			pos.y = pos.y - slotHeight - yOffset;
			pos.x = origPos.x + xOffset;
		}
	}

	//Adds item to inventory.
	public bool AddItem(Item item)
	{
		int firstNull = 0;
		bool nullFound = false;
		bool spaceInInventory = true;
		int i = 0;

		foreach (SlotScipt slot in itemSlots) {
			if (slot.GetItem () == null) 
			{
				if (!nullFound) {
					firstNull = i;
					nullFound = true;
				}
			}
			else if (slot.GetItem ().itemName == item.itemName && item.itemType == Item.ItemType.Consumable 
				&& slot.GetItem().itemAmount + item.itemAmount <= slot.maxStackSize) 
			{
				slot.IncreaseAmount (item.itemAmount);
				return spaceInInventory;
			}
			i++;
		}
		if (itemSlots [firstNull].GetItem () == null)
			itemSlots [firstNull].SetItem (item);
		else
			spaceInInventory = false;

		return spaceInInventory;
	}

    public bool ContainsKeyItemOfType(KeyItem.KeyItemType type)
    {
        foreach (SlotScipt slot in itemSlots)
        {
            if (slot.GetItem() != null)
            {
                if (slot.GetItem() is KeyItem)
                {
                    KeyItem keyItem = (KeyItem) slot.GetItem();

                    if (keyItem.keyItemType == type)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
