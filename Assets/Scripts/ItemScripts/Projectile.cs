using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public RangedWeapon.ProjectileType projectileType;

    private float movementSpeed;
    private float damage;
    private float range;
    private Vector3 direction;
    private Vector3 startingPos;
    private Character user;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

	void Update ()
    {
        if (Vector3.Distance(startingPos, _transform.position) >= range)
        {
            DestroyObject();
        }
    }

    public void SetPreferences(RangedWeapon weapon, Vector3 dir)
    {
        _transform.position = weapon.master.transform.position;
        startingPos = _transform.position;
        SetRotation(dir);

        user = weapon.master;
        movementSpeed = weapon.projectileSpeed;
        damage = weapon.damage;
        range = weapon.attackRange;
        projectileType = weapon.projectileType;
        direction = dir - _transform.position;

        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * movementSpeed;
    }

    void SetRotation(Vector3 targetPos)
    {
        targetPos = new Vector3(targetPos.x, targetPos.y, -10);
        Quaternion rot = Quaternion.LookRotation(_transform.position - targetPos, Vector3.forward);
        _transform.rotation = rot;
        _transform.eulerAngles = new Vector3(0, 0, _transform.eulerAngles.z);
    }

    void DestroyObject()
    {
        GameManager.Instance.objectPool.AddBackToPool(this);
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != user.tag && col.tag != gameObject.tag)
        {
            if(col.gameObject.GetComponent<Character>() != null)
            {
                col.GetComponent<Character>().TakeDamage(damage); 
            }

            DestroyObject();
        }
    }
}
