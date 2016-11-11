using UnityEngine;
using System.Collections;

public class MeleeAttackCollider : MonoBehaviour {
	private MeleeWeapon weapon;
	private Transform _transform;
	private bool swing;
	private float swingSpeed;

	private float rotationChange;

	void Start () 
	{
		_transform = transform.parent.transform;
		_transform.gameObject.SetActive (false);
	}

	void Update () 
	{
		if (swing) 
		{
			_transform.position = weapon.master.transform.position;
			_transform.Rotate (0,0, swingSpeed * Time.deltaTime,Space.World);
			rotationChange += swingSpeed * Time.deltaTime;

			if (rotationChange >= weapon.swingAngle) 
			{
                DeActive();
			}
		}
	}

    void DeActive()
    {
        swing = false;
        rotationChange = 0;
        _transform.gameObject.SetActive(false);
    }

	public void StartAttack(MeleeWeapon weapon)
	{
        if (!swing)
        {
            this.swing = true;
            this.weapon = weapon;
            this.swingSpeed = weapon.swingSpeed;
            Character.FacingDir dir = weapon.master.facingDir;

            if (dir == Character.FacingDir.Up)
                _transform.eulerAngles = new Vector3(0, 0, 0 - weapon.startingAngle);
            else if (dir == Character.FacingDir.Right)
                _transform.eulerAngles = new Vector3(0, 0, 90 - weapon.startingAngle);
            else if (dir == Character.FacingDir.Left)
                _transform.eulerAngles = new Vector3(0, 0, 270 - weapon.startingAngle);
            else if (dir == Character.FacingDir.Down)
                _transform.eulerAngles = new Vector3(0, 0, 180 - weapon.startingAngle);

            _transform.position = weapon.master.transform.position;
            _transform.localScale = new Vector3(weapon.swingRange, 1, 1);
        }
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (!swing)
			return;

        if (col.tag != weapon.master.tag)
        {
            if (col.gameObject.GetComponent<Character>() != null)
            {
                col.GetComponent<Character>().TakeDamage(weapon.damage);
                swing = false;

                if(weapon.master.tag == "Player")
                    weapon.ReduceDurability();
            }
        }
    }
}
