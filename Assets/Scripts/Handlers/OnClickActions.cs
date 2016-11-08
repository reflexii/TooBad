using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClickActions : MonoBehaviour {

	public LootHandler lootHandler;
	public Image draggedIcon;
	public bool dragging;

	private SlotScipt itemsOriginalSlot;
	private Item draggedItem;

	void Update()
	{
		if (dragging) 
		{
			draggedIcon.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0.4f, 0.3f, 1f);
		}
	}
		
	public void StartDragging(Item item, SlotScipt originalSlot)
	{
		itemsOriginalSlot = originalSlot;
		draggedItem = item;
		dragging = true;

		draggedIcon.gameObject.SetActive (true);
		draggedIcon.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0.3f, 0.2f, 1f);
		draggedIcon.sprite = draggedItem.itemIcon;

	}

	public void EndDragging(SlotScipt targetSlot)
	{
		//checks if itemtype matches with slot type.
		//for example: you can only equip sword to melee wep slot etc.
		//to 'item' slot you can put any type of item.
		if (targetSlot.validItemType == Item.ItemType.Item || targetSlot.validItemType == draggedItem.itemType) {
			if (targetSlot.GetItem () == null) {
				targetSlot.SetItem (draggedItem);
			} else if (targetSlot.GetItem () != null) {
				//Checks if the item is consumable, same type as target and you are able to stack (the targets size of stack is smaller than max).
				if (targetSlot.GetItem ().itemName == draggedItem.itemName && draggedItem.itemType == Item.ItemType.Consumable && targetSlot.GetItem ().itemAmount < targetSlot.maxStackSize) {
					//If dragged items stack + the size of stack of target item is greater than maxstack size, calculates correct difference and adds correct amount of items to both stacks. 
					if (targetSlot.GetItem ().itemAmount + draggedItem.itemAmount > targetSlot.maxStackSize) {
						int originalSize = draggedItem.itemAmount;
						int difference = targetSlot.maxStackSize - targetSlot.GetItem ().itemAmount;
						targetSlot.IncreaseAmount (difference);
						draggedItem.itemAmount = originalSize - difference;
						itemsOriginalSlot.SetItem (draggedItem);
					} 
					//Else just adds dragged items to the target stack.
					else
						targetSlot.IncreaseAmount (draggedItem.itemAmount);
				} else
					SwapItems (targetSlot);
			}

			ResetDrag ();

		} else
			print("Cannot equip "+draggedItem.itemType.ToString() + " to " + targetSlot.validItemType.ToString() +" slot!");
	}

    public void QuickEquip(SlotScipt slot)
    {
        if (slot.slotType == SlotScipt.SlotType.InventorySlot)
        {
            if (GameManager.Instance.inventory.QuickEquip(slot.GetItem()))
                slot.RemoveItem();
        }
        else if (slot.slotType == SlotScipt.SlotType.ActionBarSlot)
        {
            if (GameManager.Instance.inventory.gameObject.activeSelf)
            {
                if (GameManager.Instance.inventory.QuickDeEquip(slot.GetItem()))
                    slot.RemoveItem();
            }
            else
            {
                slot.EquipOrUseItem();
            }
        }
    }
		
	void SwapItems(SlotScipt targetSlot)
	{
		Item tmp = targetSlot.GetItem ();
		targetSlot.SetItem (draggedItem);
		itemsOriginalSlot.SetItem (tmp);
		ResetDrag ();
	}

	void ResetDrag()
	{
		dragging = false;
		draggedItem = null;
		itemsOriginalSlot = null;
		draggedIcon.gameObject.SetActive (false);
	}
}
