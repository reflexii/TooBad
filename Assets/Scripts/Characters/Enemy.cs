using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public Transform player;
    public Transform raycastOrigin;
    public bool visibleRaycast = true;
    public int layerMask = 1 << 9;
    public float movementSpeed;
    public float spotDistance;
    public float damage;
    public EnemyType enemyType;

    public bool chargeAttacks = true;
    public float chargeTime = 1;

    protected float attackRange;
    protected Animator _animator;

    protected const string attackDir = "attackDirection";
    protected const string moveDir = "movementDirection";
    protected const string attackUltimate = "ultimateAttack";

    protected bool attacking = false;
    protected bool moving = false;

    private float currentCharge;
    private bool charging;

    void Start()
    {
        SetPreferences();
        SetWeapon();
    }

	protected virtual void Update ()
    {
        Move();
    }

    public void DropLoot()
    {
        GameManager.Instance.objectPool.DropItem(transform.position);
    }

    void SetWeapon()
    {
        if (enemyType == EnemyType.FistFighter)
        {
            equippedWeapon = new Weapons.Fist();
        }
        else if (enemyType == EnemyType.Archer)
        {
            equippedWeapon = new Weapons.CrossBow();
        }
        else if (enemyType == EnemyType.Mage)
        {
            equippedWeapon = new Weapons.FireWand();
        }

        equippedWeapon.master = this;
        attackRange = equippedWeapon.attackRange;

        if (damage != 0)
        {
            equippedWeapon.damage = damage;
        }
    }

    public void SetPreferences()
    {
        transform.tag = "Enemy";
        _animator = GetComponent<Animator>();
        player = GameManager.Instance.player.transform;
        currentHealth = maxHealth;
    }

    public override void OnDeath()
    {
        DropLoot();
        GameManager.Instance.soundManager.playEnemyDeathSound();
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
            //If the enemy is required to charge attacks before launching it.
            if (chargeAttacks)
            {
                if (currentCharge < chargeTime)
                {
                    charging = true;
                    currentCharge += Time.deltaTime;
                    return;
                }
                else
                {
                    currentCharge = 0;
                    charging = false;
                }
            }

            facingDir = DirectionConverter.DirectionPlayerToPlayer(transform.position, player.position);

            if (_animator != null && !equippedWeapon.onCooldown)
            {
                UpdateAttackDirection();
                attacking = true;
                equippedWeapon.Attack(this, dir);
            }
        }
    }

    public void aggroPlayer() {
        if (player.gameObject != null && gameObject != null) {
            Vector3 direction = player.transform.position - gameObject.transform.position;
            facingDir = DirectionConverter.DirectionPlayerToPlayer(transform.position, player.position);
            if ((player.transform.position - gameObject.transform.position).magnitude < attackRange || charging) {
                Attack(player.position);
            } else if(!charging){
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
                //Debug.Log("Wall in the way!");
            }
        } 
    }

    public enum EnemyType
    {
        Archer,
        FistFighter,
        Mage
    }
}
