using UnityEngine;
using System.Collections;

public class Item {

	public string itemName;
	public ItemType itemType;
	public int itemAmount;
	//Placeholder for sprite.
	public Sprite itemIcon;
	public Character master;
    public SlotScipt slot;

	public Item(string itemName, ItemType itemType, IconType iconType)
	{
		this.itemName = itemName;
		this.itemType = itemType;
		this.itemIcon = GameManager.Instance.assetManager.GetIcon(iconType);
		itemAmount = 1;
	}

	public Item(string itemName, ItemType itemType, IconType iconType, Character master)
	{
		this.itemName = itemName;
		this.itemType = itemType;
        this.itemIcon = GameManager.Instance.assetManager.GetIcon(iconType);
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
		Consumable,
        KeyItem
	}

    public enum IconType
    {
        Potion,
        Sword,
        Axe,
        Crossbow,
        NormalKey,
        Wand,
        Mace
    }
}
