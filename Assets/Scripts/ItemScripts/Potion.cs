using UnityEngine;
using System.Collections;

public class Potion : Item {

	public float healAmount;

	public Potion (string itemName, float healAmount, Color itemIcon) : base (itemName, ItemType.Consumable , itemIcon)
	{
		this.healAmount = healAmount;
	}

	//Used by actionBar. When potion is clicked or hotkey has been pressed.
	public override void TakeAction(SlotScipt slot)
	{
		//ToAdd player healing action here.
		//Debug.Log("Consumed " + itemName + "!");
		itemAmount--;

		if (itemAmount <= 0)
			slot.RemoveItem ();	
	}
}
