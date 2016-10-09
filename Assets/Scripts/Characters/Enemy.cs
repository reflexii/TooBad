using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public Transform player;
    public Transform raycastOrigin;
    public bool visibleRaycast = true;
    public int layerMask = 1 << 9;
    public float movementSpeed;
    public float spotDistance;

    void Awake()
    {
        transform.tag = "Enemy";
    }

	void Update ()
    {
        RayCasting();
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

    public void aggroPlayer() {
        if (player.gameObject != null && gameObject != null) {
            Vector3 direction = player.transform.position - gameObject.transform.position;
            if ((player.transform.position - gameObject.transform.position).magnitude < 1.5f) {
                Debug.Log("Stopping to attack player");
                Attack(player.transform.position - gameObject.transform.position);
            } else {
                Debug.Log("Chasing!");
                gameObject.transform.position += direction * movementSpeed * Time.deltaTime;
            }
        } 
    }

    public void RayCasting() {
        if ((player.transform.position - gameObject.transform.position).magnitude < spotDistance) {
            //draws a line, if visibleRaycast = true
            if (visibleRaycast) {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.white);
            }

            float magnitude = (transform.position - player.transform.position).magnitude;
            if (!Physics2D.Raycast(transform.position, player.transform.position - transform.position, magnitude, layerMask)) {
                aggroPlayer();
            } else {
                Debug.Log("Wall in the way!");
            }
        } 
    }
}
