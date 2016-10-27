using UnityEngine;
using System.Collections;

public abstract class Consumable : Item {

	public Consumable (string itemName, ItemClass iconType) : base (itemName, ItemType.Consumable , iconType)
	{

	}

	//Used by actionBar. When potion is clicked or hotkey has been pressed.
	public override void TakeAction(SlotScipt slot)
	{
        Action();
		itemAmount--;
		if (itemAmount <= 0 && slot != null)
			slot.RemoveItem ();	
	}

    protected abstract void Action();
}
