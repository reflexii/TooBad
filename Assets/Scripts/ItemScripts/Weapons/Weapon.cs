using UnityEngine;
using System.Collections;

public abstract class Weapon : Item {

	public float damage;
    public float attackSpeed;
	public int durability;
	public int currentDurability;
    public float attackRange;
    public bool onCooldown;

    protected float lastTimeAttacked;

	public Weapon (string itemName, float damage, float attackRange, int durability, ItemClass iconType) : base (itemName, ItemType.Weapon , iconType)
	{
		this.damage = damage;
		this.durability = durability;
        this.attackRange = attackRange;
		currentDurability = durability;
	}

	//Used by actionBar. When weapon is clicked or hotkey has been pressed.
	public override void TakeAction(SlotScipt slot)
	{
        this.slot = slot;
		master.EquipWeapon (this);
	}

    //Sword swing, shoot projectile...
    public virtual void Attack(Character player, Vector3 dir)
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
