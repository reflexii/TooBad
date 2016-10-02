using UnityEngine;
using System.Collections;

public abstract class Weapon : Item {

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
        this.slot = slot;
		master.SetWeapon (this);
	}

    //Sword swing, shoot projectile...
    public virtual void Attack(Player player, Vector3 dir)
	{
        
	}

    public void ReduceDurability()
    {
        currentDurability -= 1;
        slot.UpdateItemDurability();
        if (currentDurability <= 0)
        {
            slot.RemoveItem();
        }
    }
}
