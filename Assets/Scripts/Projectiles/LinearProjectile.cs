using UnityEngine;
using System.Collections;

public class LinearProjectile : Projectile
{
    public override void SetPreferences(RangedWeapon weapon, Vector3 dir)
    {
        base.SetPreferences(weapon, dir);
        AddForce();

    }

    public override void Move()
    {
        if (Vector3.Distance(startingPos, _transform.position) >= range)
        {
            DestroyObject();
        }
    }

    void AddForce()
    {
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * movementSpeed;
    }
}