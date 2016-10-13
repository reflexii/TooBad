using UnityEngine;
using System.Collections;

public class BreakAbleObject : Character
{
    void Awake()
    {
        gameObject.tag = "Enemy";
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }
}
