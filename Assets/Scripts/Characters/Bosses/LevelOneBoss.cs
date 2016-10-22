using UnityEngine;
using System.Collections;

public class LevelOneBoss : Enemy {
    public float attackSpeed;
    public bool targetThePlayer;
    public GameObject shield;

	void Awake ()
    {
        transform.tag = "Enemy";
        equippedWeapon = new Weapons.Boomerang();
        equippedWeapon.master = this;
        attackRange = equippedWeapon.attackRange;

        if(attackSpeed != 0)
            equippedWeapon.attackSpeed = attackSpeed;
    }

    public override void Move()
    {
        if (targetThePlayer)
        {
            Attack(player.transform.position);
        }
        else
        {
            Vector3 spotToAttack = transform.position;
            spotToAttack.y -= (int)Random.Range(2, 10);
            spotToAttack.x -= (int)Random.Range(2, 10);
            Attack(spotToAttack);
        }
    }

    public override void TakeDamage(float dmgAmount)
    {
        if (shield == null)
        {
            base.TakeDamage(dmgAmount);
        }
    }

}
