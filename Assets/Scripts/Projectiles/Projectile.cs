﻿using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

    public RangedWeapon.ProjectileType projectileType;

    protected float movementSpeed;
    protected float damage;
    protected float range;
    protected Vector3 direction;
    protected Vector3 targetPos;
    protected Vector3 startingPos;
    protected Character user;
    protected bool hitItself;

    protected Rigidbody2D _rigidbody;
    protected Transform _transform;

    private string userTag;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
        tag = "Projectile";
    }

	void Update ()
    {
        Move();
    }

    public virtual void Move()
    { }

    public virtual void SetPreferences(RangedWeapon weapon, Vector3 targetPos)
    {
        Vector3 tmpPos = weapon.master.transform.position;
        tmpPos.z = 0;
        _transform.position = tmpPos;
        startingPos = _transform.position;
        this.targetPos = targetPos;
        SetRotation(targetPos);

        user = weapon.master;
        movementSpeed = weapon.projectileSpeed;
        damage = weapon.damage;
        range = weapon.attackRange;
        projectileType = weapon.projectileType;
        direction = targetPos - _transform.position;

        userTag = user.tag;
    }

    void SetRotation(Vector3 targetPos)
    {
        targetPos = new Vector3(targetPos.x, targetPos.y, -10);
        Quaternion rot = Quaternion.LookRotation(_transform.position - targetPos, Vector3.forward);
        _transform.rotation = rot;
        _transform.eulerAngles = new Vector3(0, 0, _transform.eulerAngles.z);
    }

    protected void DestroyObject()
    {
        if (projectileType == RangedWeapon.ProjectileType.FireBall)
        {
            GameManager.Instance.objectPool.CreateExplosion(_transform.position);
        }

        GameManager.Instance.objectPool.AddBackToPool(this);
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != userTag && col.tag != tag && col.tag != "ClickAble")
        {
            if (col.gameObject.GetComponent<Character>() != null)
            {
                col.GetComponent<Character>().TakeDamage(damage);
            }

            DestroyObject();
        }
        else
        {
            hitItself = true;
        }
    }
}
