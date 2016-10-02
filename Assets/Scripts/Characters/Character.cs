using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour 
{
	[HideInInspector]
	public Weapon equippedWeapon;
    [HideInInspector]
	public FacingDir facingDir;
    public MeleeAttackCollider meleeAttackAction;
    public float maxHealth;
	private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

	public void TakeDamage (float dmgAmount)
	{
		currentHealth -= dmgAmount;

		if (currentHealth <= 0) 
		{
            OnDeath();
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

    public virtual void OnDeath()
    {
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
