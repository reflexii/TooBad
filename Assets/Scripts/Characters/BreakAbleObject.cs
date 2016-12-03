using UnityEngine;
using System.Collections;

public class BreakAbleObject : Character
{
    private Animator _animator;
    private float timeTillDeath = 1f;
    private float deathTime;
    private bool destroyed;

    void Awake()
    {
        gameObject.tag = "Enemy";
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (deathTime != 0)
        {
            if (Time.time - deathTime >= timeTillDeath)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void OnDeath()
    {
        if (_animator != null && !destroyed)
        {
            deathTime = Time.time;
            _animator.SetTrigger("Explode");
            destroyed = true;
            _animator = null;
            GameManager.Instance.soundManager.playTableBreakSound();
        }
    }
}
