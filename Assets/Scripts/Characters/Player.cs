using UnityEngine;
using System.Collections;

public class Player : Character 
{
	public MeleeAttackCollider meleeAttackAction;
		
	public override void Attack(Vector3 dir)
	{
		if(equippedWeapon != null)
			equippedWeapon.Attack (this,dir);
	}
}
