using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelOneBoss : Enemy {

    public float weaponOneAttackSpeed;
    public float weaponTwoAttackSpeed;
    public float wanderingRadius;
    public float timeUntilUltimate = 7;

    public bool targetThrow;
    public bool randomThrow;
    public bool spinThrow;
    public int rangedWeaponAmount = 6;
    public float turningSpeed;

    public GameObject shield;
    public GameObject spotToAttackDebug;

    private Weapon weaponOne;
    private Weapon weaponTwo;
    private List<Weapon> weapons = new List<Weapon>();

    private Vector3 movDestination;
    private Vector3 startingPos;
    private Vector2 spotToAttack;
    private float angle = 0;
    private Vector2 centre;
    private Vector2 offset;
    private float timer;

    private bool prepareUltimate;
    private bool readyForUltimate;
    private int throwDir = 1;
    public bool phaseTwo;

    void Start ()
    {
        SetPreferences();

        weaponOne = new Weapons.Boomerang();
        weaponTwo = new Weapons.Boomerang();
        for (int i = 0; i < 100; i++)
            weapons.Add(new Weapons.AutomaticCrossBow());

        EquipWeapon(weaponOne);
        movDestination = transform.position;
        startingPos = transform.position;

        if(weaponOneAttackSpeed != 0)
            weaponOne.attackSpeed = weaponOneAttackSpeed;

        Vector3 spotToAttack = transform.position;
        spotToAttack.y -= (int)Random.Range(2, 10);
        spotToAttack.x -= (int)Random.Range(2, 10);
    }

    protected override void Update()
    {
        base.Update();

        if (shield == null)
        {
            phaseTwo = true;
        }
    }

    public override void OnDeath() {
        DropLoot();
        GameManager.Instance.soundManager.playBossDeathSound();
        Destroy(gameObject);
    }

    public override void Move()
    {
        AttackPattern();

        if (!phaseTwo)
            return;

        if ((movDestination - gameObject.transform.position).magnitude <= 0.2f)
        {
            if (!prepareUltimate)
            {
                Vector3 randomizePos = (Random.insideUnitCircle * wanderingRadius);
                movDestination = randomizePos + startingPos;
            }
            else
            {
                readyForUltimate = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movDestination, movementSpeed * Time.deltaTime);
        }
    }

    public override void TakeDamage(float dmgAmount)
    {
        if (shield == null)
        {
            phaseTwo = true;
            EquipWeapon(weaponTwo);
            base.TakeDamage(dmgAmount);
        }
    }

    protected override void UpdateAttackDirection()
    {
        if (!readyForUltimate)
        {
            if (throwDir % 2 != 0)
            {
                facingDir = FacingDir.Left;
            }
            else
            {
                facingDir = FacingDir.Right;
            }
            throwDir++;
            _animator.SetBool(attackUltimate,false);
            base.UpdateAttackDirection();
        }
        else
        {
            if(!_animator.GetBool(attackUltimate))
                _animator.SetBool(attackUltimate,true);
        }
    }

    void AttackPattern()
    {
        if (targetThrow && phaseTwo)
        {
            if (!prepareUltimate)
            {
                weaponTwo.attackSpeed = weaponTwoAttackSpeed;
                TargetThrow();
            }
        }
        else if (randomThrow)
        {
            weaponOne.attackSpeed = weaponOneAttackSpeed;
            RandomThrow();
        }
        if (spinThrow && phaseTwo)
        {
            if (timer >= timeUntilUltimate)
            {
                prepareUltimate = true;
                movDestination = startingPos;

                if (readyForUltimate)
                {
                    SpinThrow();
                }
                else
                {
                    attacking = false;
                    _animator.SetBool("attacking", attacking);
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    void SpinThrow()
    {
        centre = transform.position;
        angle += turningSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        float tmpAngle = angle;
        int i = 0;
        foreach (Weapon weapon in weapons)
        {
            if (weapon is Weapons.AutomaticCrossBow && i < rangedWeaponAmount)
            {
                if (i == 0)
                {
                    EquipWeapon(weapon);
                    Attack(centre + offset);
                    spotToAttackDebug.transform.position = centre + offset;
                }
                else
                {
                    EquipWeapon(weapon);
                    tmpAngle = GetShootingAngle(tmpAngle);
                    var tmpOffset = new Vector2(Mathf.Sin(tmpAngle), Mathf.Cos(tmpAngle));
                    Attack(centre + tmpOffset);
                }
                i++;
            }
        }

        if (angle >= 6)
        {
            prepareUltimate = false;
            readyForUltimate = false;
            timer = 0;
            angle = 0;
            EquipWeapon(weaponTwo);
        }
    }

    float GetShootingAngle(float angle)
    {
        float toReturn = angle - ((6.33f / 360f) * (360f / rangedWeaponAmount));
        return toReturn;
    }

    void TargetThrow()
    {
        Attack(player.transform.position);
    }

    void RandomThrow()
    {
        spotToAttack = transform.position;
        spotToAttack.y -= (int)Random.Range(-10, 10);
        spotToAttack.x -= (int)Random.Range(-10, 10);
        Attack(spotToAttack);
    }
}
