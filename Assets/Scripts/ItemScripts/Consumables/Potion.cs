using UnityEngine;
using System.Collections;
using System;

public class Potion : Consumable
{
    float healAmount;

    public Potion(string itemName, float healAmount, ItemClass iconType) : base(itemName, iconType)
    {
        this.healAmount = healAmount;
    }

    protected override void Action()
    {
        master.currentHealth += healAmount;

        if (master.currentHealth > master.maxHealth)
        {
            master.currentHealth = master.maxHealth;
        }
    }
}
