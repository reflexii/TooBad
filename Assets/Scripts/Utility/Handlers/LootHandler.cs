﻿using UnityEngine;
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
		if (Input.GetKeyDown (KeyCode.Alpha0))
			LootItem (new Weapons.LongSword ());
		if (Input.GetKeyDown (KeyCode.Alpha6))
			LootItem (new Consumables.SmallPotion ());
        if (Input.GetKeyDown(KeyCode.Alpha9))
            LootItem(new Weapons.CrossBow());
        if (Input.GetKeyDown(KeyCode.Alpha8))
            LootItem(new Weapons.FireWand());;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            LootItem(new Weapons.Axe()); ;
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.Instance.dialogManager.NextDialog();

        if (Input.GetKeyDown(KeyCode.Escape) && StateManager.Instance.activeState.sceneType == State.SceneType.Level && !GameManager.Instance.ingameMenu.forcedMenu)
        {
            if (GameManager.Instance.dialogManager.confirmationDialog.gameObject.activeSelf)
                GameManager.Instance.dialogManager.confirmationDialog.gameObject.SetActive(false);
            else
                GameManager.Instance.ingameMenu.OpenMenu(IngameMenu.MenuState.RestartLevel,false);
        }

        /*if (Input.GetKeyDown (KeyCode.I))
			inventory.gameObject.SetActive (!inventory.gameObject.activeSelf);*/

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
