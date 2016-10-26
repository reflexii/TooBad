using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Character 
{

    public Image healthBar;
    public Image rageBar;
    public float maxRageAmount;
    public float rageDegenPerSecond;

    private MovementScript ms;
    private float currentRageAmount;

    void Awake() {
        currentRageAmount = maxRageAmount;
        ms = GetComponent<MovementScript>();
    }

	public override void Attack(Vector3 dir)
	{
		if(equippedWeapon != null) {
            equippedWeapon.Attack(this, dir);
            playAnimation();
        }
			
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

    public void playAnimation() {
        if (equippedWeapon.itemName == "Long Sword") {
            ms.swingSword = true;
        }
    }
}
