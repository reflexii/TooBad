using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour 
{
	[HideInInspector]
	public Weapon equippedWeapon;
    [HideInInspector]
	public FacingDir facingDir;
	public float maxHealth;
	private float currentHealth;

	public void TakeDamage (float dmgAmount)
	{
		currentHealth -= dmgAmount;

		if (currentHealth <= 0) 
		{
			//ADD something here.
		}
	}

	public void SetWeapon(Weapon weapon)
	{
		equippedWeapon = weapon;
	}

    public void UnEquip()
    {
        equippedWeapon = null;
    }

    public virtual void Attack (Vector3 dir)
	{
		//ADD something here.
	}

    public enum FacingDir
    {
        Right,
        Left,
        Up,
        Down
    }

}
