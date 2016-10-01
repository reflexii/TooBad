using UnityEngine;
using System.Collections;

public class Weapon : Item {

	public float damage;
    public float attackSpeed;
	public int durability;
	public int currentDurability;

    protected float lastTimeAttacked;

	public Weapon (string itemName, float damage, int durability, Color itemIcon) : base (itemName, ItemType.Weapon , itemIcon)
	{
		this.damage = damage;
		this.durability = durability;
		currentDurability = durability;
	}

	//Used by actionBar. When weapon is clicked or hotkey has been pressed.
	public override void TakeAction(SlotScipt slot)
	{
		master.SetWeapon (this);
	}

    //Sword swing, shoot projectile...
    public virtual void Attack(Player player, Vector3 dir)
	{

	}
}
