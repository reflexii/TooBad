using UnityEngine;
using System.Collections;

public class CircularProjectile : Projectile
{
    public float rotationSpeed = 500;

    private float RotateSpeed = 2.5f;
    private float Radius = 1f;

    private Vector2 _centre;
    private float _angle;
    private float totalTravel;
    private Direction throwDir;

    public override void SetPreferences(RangedWeapon weapon, Vector3 dir)
    {
        base.SetPreferences(weapon, dir);
        targetPos.z = 0;
        totalTravel = 0;

        _centre = _transform.position + ((targetPos - _transform.position) / 2);
        Radius = Vector3.Distance(targetPos, _transform.position) / 2;
        range = 4;

        if (Random.Range(0, 2) == 0)
        {
            throwDir = Direction.Left;
        }
        else
        {
            throwDir = Direction.Right;
        }

        AdjustStartingPos();
    }

    void AdjustStartingPos()
    {
        int i = 0;

        while (true)
        {
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            _transform.position = _centre + offset;

            if (Vector3.Distance(_transform.position, user.gameObject.transform.position) <= 0.25f)
            {
                break;
            }

            if (i >= 10000)
            {
                break;
            }

            i++;
        }
    }

    void Rotate()
    {
        _transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    public override void Move()
    {
        Rotate();

        if (throwDir == Direction.Right)
        {
            _angle += RotateSpeed * Time.deltaTime;
        }
        else if (throwDir == Direction.Left)
        {
            _angle -= RotateSpeed * Time.deltaTime;
        }

        totalTravel += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        _transform.position = _centre + offset;

        if (totalTravel >= range)
        {
            DestroyObject();
        }
    }

    private enum Direction
    {
        Right,
        Left
    }
}
