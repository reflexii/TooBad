using UnityEngine;
using System.Collections;

public class MeleeWeapon : Weapon {
    public float startingAngle;
    public float swingRange;
    public float swingAngle;
    public float swingSpeed;

    public MeleeWeapon(string itemName, float damage, int durability, float startingAngle, float swingAngle, float swingRange, float swingSpeed, ItemClass iconType) : base(itemName, damage, swingRange, durability, iconType)
    {
        this.startingAngle = startingAngle * -1;
        this.swingRange = swingRange;
        this.swingAngle = swingAngle;
        this.swingSpeed = swingSpeed;
    }

    public override void Attack(Character player, Vector3 dir)
    {
        player.meleeAttackAction.transform.parent.gameObject.SetActive(true);
        player.meleeAttackAction.StartAttack(this);
    }
}
