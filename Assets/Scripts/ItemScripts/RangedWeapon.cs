using UnityEngine;
using System.Collections;
using System;

public class RangedWeapon : Weapon
{
    public float range;
    public float projectileSpeed;
    public ProjectileType projectileType;

    public RangedWeapon(string itemName, float damage, int durability, float attackSpeed, float projectileSpeed,float range, ProjectileType projectileType, Color itemIcon) : base(itemName, damage, durability, itemIcon)
    {
        this.projectileSpeed = projectileSpeed;
        this.projectileType = projectileType;
        this.attackSpeed = attackSpeed;
        this.range = range;
    }

    public override void Attack(Player player, Vector3 dir)
    {
        if (DateTime.Now.Second - lastTimeAttacked >= attackSpeed ||lastTimeAttacked == 0)
        {
            GameManager.Instance.objectPool.FireProjectile(this, dir);
            lastTimeAttacked = DateTime.Now.Second;
        }
    }
    public enum ProjectileType
    {
        Arrow,
        FireBall
    }
}
