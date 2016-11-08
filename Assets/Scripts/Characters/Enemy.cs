using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public Transform player;
    public Transform raycastOrigin;
    public bool visibleRaycast = true;
    public int layerMask = 1 << 9;
    public float movementSpeed;
    public float spotDistance;

    protected float attackRange;
    protected Animator _animator;

    protected const string attackDir = "attackDirection";
    protected const string moveDir = "movementDirection";
    protected const string attackUltimate = "ultimateAttack";

    protected bool attacking = false;
    protected bool moving = false;

    void Awake()
    {
        SetPreferences();
        equippedWeapon = new Weapons.Fist();
        equippedWeapon.master = this;
        attackRange = equippedWeapon.attackRange;
    }

	protected virtual void Update ()
    {
        Move();
    }

    void DropLoot()
    {
        GameManager.Instance.objectPool.DropItem(transform.position);
    }

    public void SetPreferences()
    {
        transform.tag = "Enemy";
        _animator = GetComponent<Animator>();
    }

    public override void OnDeath()
    {
        DropLoot();
        Destroy(gameObject);
    }

    public override void Move()
    {
        attacking = false;
        RayCasting();

        if (_animator != null)
        {
            _animator.SetBool("attacking", attacking);
            UpdateMovementDirection();
        }
    }


    protected virtual void UpdateAttackDirection()
    {
        if (facingDir == FacingDir.Up)
        {
            _animator.SetInteger(attackDir, 1);
        }
        else if (facingDir == FacingDir.Down)
        {
            _animator.SetInteger(attackDir, 2);
        }
        else if (facingDir == FacingDir.Left)
        {
            _animator.SetInteger(attackDir, 3);
        }
        else if (facingDir == FacingDir.Right)
        {
            _animator.SetInteger(attackDir, 4);
        }
        _animator.SetBool("attacking", attacking);
    }

    protected virtual void UpdateMovementDirection()
    {
        if (facingDir == FacingDir.Up)
        {
            _animator.SetInteger(moveDir, 1);
        }
        else if (facingDir == FacingDir.Down)
        {
            _animator.SetInteger(moveDir, 2);
        }
        else if (facingDir == FacingDir.Left)
        {
            _animator.SetInteger(moveDir, 3);
        }
        else if (facingDir == FacingDir.Right)
        {
            _animator.SetInteger(moveDir, 4);
        }
        _animator.SetBool("moving", moving);
    }

    public override void Attack(Vector3 dir)
    {
        if (equippedWeapon != null)
        {
            facingDir = DirectionConverter.DirectionPlayerToPlayer(transform.position, player.position);

            if (_animator != null && !equippedWeapon.onCooldown)
            {
                UpdateAttackDirection();
                attacking = true;
            }
            equippedWeapon.Attack(this, dir);
        }
    }

    public void aggroPlayer() {
        if (player.gameObject != null && gameObject != null) {
            Vector3 direction = player.transform.position - gameObject.transform.position;
            facingDir = DirectionConverter.DirectionPlayerToPlayer(transform.position, player.position);
            if ((player.transform.position - gameObject.transform.position).magnitude < attackRange) {
                Attack(player.position);
            } else {
                moving = true;
                gameObject.transform.position += direction * movementSpeed * Time.deltaTime;
            }
        } 
    }

    public void RayCasting() {
        moving = false;
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
