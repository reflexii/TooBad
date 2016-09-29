using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootHandler : MonoBehaviour 
{
	public Character looter;
	public Inventory inventory;
	public GameObject lootPrefab;

	void Update()
	{
		//REMOVE THESE!
		if (Input.GetKeyDown (KeyCode.Keypad1))
			LootItem (new Weapons.LongSword ());
		if (Input.GetKeyDown (KeyCode.Keypad2))
			LootItem (new Potions.SmallPotion ());
		if (Input.GetKeyDown (KeyCode.Keypad0))
			inventory.gameObject.SetActive (false);
		if (Input.GetKeyDown (KeyCode.KeypadPeriod))
			inventory.gameObject.SetActive (true);

		if (Input.GetKeyDown (KeyCode.KeypadPlus)) {
			GameObject o = (GameObject)Instantiate (lootPrefab);
			o.GetComponent<LootableItem> ().SetItem (new Weapons.ShortSword ());
		}
	}

	public void LootItem(Item item)
	{
		item.master = looter;
		inventory.AddItem (item);
		//	print ("INVENTORY IS FULL");
	}

	public void LootItem(LootableItem lootItem)
	{
		lootItem.GetItem().master = looter;
		if (inventory.AddItem (lootItem.GetItem()))
			/*print ("INVENTORY IS FULL");
		else*/
			lootItem.DestroyItem();
	}
}
