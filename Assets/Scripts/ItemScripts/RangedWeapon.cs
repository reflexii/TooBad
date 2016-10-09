﻿using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
    public float projectileSpeed;
    public ProjectileType projectileType;

    public RangedWeapon(string itemName, float damage, int durability, float attackSpeed, float projectileSpeed,float range, ProjectileType projectileType, Color itemIcon) : base(itemName, damage,range, durability, itemIcon)
    {
        this.projectileSpeed = projectileSpeed;
        this.projectileType = projectileType;
        this.attackSpeed = attackSpeed;
    }

    public override void Attack(Character player, Vector3 dir)
    {
        if (Time.time - lastTimeAttacked >= attackSpeed ||lastTimeAttacked == 0)
        {
            GameManager.Instance.objectPool.FireProjectile(this, dir);
            lastTimeAttacked = Time.time;

            if(player is Player)
                ReduceDurability();
        }
    }
    public enum ProjectileType
    {
        Arrow,
        FireBall
    }
}
