using UnityEngine;
using System.Collections;

public class Weapon : Item {

	public float damage;
	public int durability;
	public int currentDurability;

	public Weapon (string itemName, float damage, int durability, Color itemIcon) : base (itemName, ItemType.Weapon , itemIcon)
	{
		this.damage = damage;
		this.durability = durability;
		currentDurability = durability;
	}

	//Used by actionBar. When weapon is clicked or hotkey has been pressed.
	public override void TakeAction(SlotScipt slot)
	{
		//ToAdd weapon equipping here
		//Debug.Log("Equipped " + itemName + "!");
	}

	//ToAdd either the target of attack to this method or call this method by enemy when hitted and return the amount of damage dealt.
	public void DealDamage()
	{
		//ToAdd damage dealing stuff.
		//ToAdd reference to the current slot to update the state of durability?
	}
}
