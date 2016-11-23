using UnityEngine;
using System.Collections;

public class BreakAbleObject : Character
{
    private Animator _animator;
    private float timeTillDeath = 1f;
    private float deathTime;
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
        deathTime = Time.time;
        if (_animator != null)
        {
            _animator.SetTrigger("Explode");
            _animator = null;
        }
        GameManager.Instance.soundManager.playTableBreakSound();
    }
}
