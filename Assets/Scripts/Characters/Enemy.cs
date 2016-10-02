using UnityEngine;
using System.Collections;

public class Enemy : Character {

    void Awake()
    {
        transform.tag = "Enemy";
    }

	void Update ()
    {
	
	}

    void DropLoot()
    {
        GameManager.Instance.objectPool.DropItem(transform.position);
    }

    public override void OnDeath()
    {
        DropLoot();
        Destroy(gameObject);
    }
}
