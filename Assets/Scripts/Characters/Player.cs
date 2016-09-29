using UnityEngine;
using System.Collections;

public class Player : Character 
{
	public MeleeAttackCollider meleeAttackAction;
	public RangedAttack rangedAttackAction;
		
	public override void Attack()
	{
		if(equippedWeapon != null)
			equippedWeapon.Attack (this);
	}
}
