using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Character 
{

    public Image healthBar;
    public Image rageBar;
    private float currentRageAmount;
    public float maxRageAmount;
    public float rageDegenPerSecond;

    void Awake() {
        currentRageAmount = maxRageAmount;
    }

	public override void Attack(Vector3 dir)
	{
		if(equippedWeapon != null)
			equippedWeapon.Attack (this,dir);
	}

    void Update() {
        updateHealthBar();
        drainRage();
    }
    
    public void updateHealthBar() {
        healthBar.fillAmount = (currentHealth / maxHealth);
    }

    public void drainRage() {
        currentRageAmount -= rageDegenPerSecond * Time.deltaTime;
        rageBar.fillAmount = (currentRageAmount / maxRageAmount);
    }
}
