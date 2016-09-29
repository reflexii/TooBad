using UnityEngine;
using System.Collections;

public class Item {

	public string itemName;
	public ItemType itemType;
	public int itemAmount;
	//Placeholder for sprite.
	public Color itemIcon;
	public Character master;

	public Item(string itemName, ItemType itemType, Color itemColor)
	{
		this.itemName = itemName;
		this.itemType = itemType;
		this.itemIcon = itemColor;
		itemAmount = 1;
	}

	public Item(string itemName, ItemType itemType, Color itemColor, Character master)
	{
		this.itemName = itemName;
		this.itemType = itemType;
		this.itemIcon = itemColor;
		itemAmount = 1;
		this.master = master;
	}

	public virtual void TakeAction(SlotScipt slot)
	{

	}

	public enum ItemType
	{
		//Use Item only as slotType!!
		Item,
		Weapon,
		Consumable
	}
}
