using UnityEngine;
using System.Collections;

public class LevelOneBoss : Enemy {
    public GameObject shield;

	void Awake ()
    {
	
	}

    public override void Move()
    {
        
    }

    public override void TakeDamage(float dmgAmount)
    {
        if (shield == null)
        {
            base.TakeDamage(dmgAmount);
        }
    }

}
