using UnityEngine;
using System.Collections;

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
        if (Time.time - lastTimeAttacked >= attackSpeed ||lastTimeAttacked == 0)
        {
            ReduceDurability();
            GameManager.Instance.objectPool.FireProjectile(this, dir);
            lastTimeAttacked = Time.time;
        }
    }
    public enum ProjectileType
    {
        Arrow,
        FireBall
    }
}
