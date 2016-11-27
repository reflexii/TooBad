using UnityEngine;
using System.Collections;

public abstract class Weapon : Item {

	public float damage;
    public float attackSpeed;
	public int durability;
	public int currentDurability;
    public float attackRange;
    public bool onCooldown
    {
        set { }
        get
        {
            if(Time.time - lastTimeAttacked >= attackSpeed ||lastTimeAttacked == 0)
            {
                return false;
            }
            return true;
        }
    }

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
        if (durability != 0)
            currentDurability -= 1;
        else
            return;

        slot.UpdateItemDurability();
        GameManager.Instance.objectPool.CreatePopUpText(GameManager.Instance.player.transform.position, "-1 " + itemName, PopUpText.TextType.Negative);

        if (currentDurability <= 0)
        {
            //slot.RemoveItem();
        }
    }
}
