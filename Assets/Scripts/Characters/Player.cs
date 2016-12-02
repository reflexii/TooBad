using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Character 
{

    public Image healthBar;
    public Image rageBar;
    public float maxRageAmount;
    public float rageDegenPerSecond;
    [HideInInspector]
    public float currentRageAmount;
    public BoxCollider2D box2d;
    public BoxCollider2D secondbox2d;


    private MovementScript ms;

    void Awake() {
        currentRageAmount = maxRageAmount;
        ms = GetComponent<MovementScript>();
        GameManager.Instance.OnStartGame += OnStartGame;
        ms.enabled = false;
    }

	public override void Attack(Vector3 dir)
	{
        if (!ms.dead) {
            if (equippedWeapon != null && !equippedWeapon.onCooldown) {
            equippedWeapon.Attack(this, dir);
            
                playAnimation();
                playSound();
            }
            
        }
			
	}

    public override void TakeDamage(float dmgAmount) {
        base.TakeDamage(dmgAmount);
        GameManager.Instance.soundManager.playPlayerDamagedSound();
    }

    public override void OnDeath() {
        GameManager.Instance.soundManager.playPlayerDeathSound();
        box2d.enabled = false;
        secondbox2d.enabled = false;

        //TODO: player dying visuals
        ms.playerIsDead = true;
        ms.dead = true;

        Invoke("restartGame", 5f);

    }

    void restartGame() {
        /*
        StateManager.Instance.SwitchScene(State.SceneID.LevelOne);
        currentHealth = maxHealth;
        ms.playerIsDead = false;
        ms.dead = false;
        box2d.enabled = true;
        secondbox2d.enabled = true;
        equippedWeapon = null;
        */

        //This defines if the player will be able to restart level or to restart the boss fight. Boss fight reset not implemented yet.
        IngameMenu.MenuState ms;

        if(GameManager.Instance.bossState)
        {
            ms = IngameMenu.MenuState.RestartBoss;
        }
        else
        {
            ms = IngameMenu.MenuState.RestartLevel;
        }

        //Opens ingame-menu, player is able to choose what he/she wants to do.
        GameManager.Instance.ingameMenu.OpenMenu(ms, true);
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
        if (equippedWeapon != null) {
            if (equippedWeapon.itemClass == Item.ItemClass.Sword) {
                ms.swingSword = true;
            } else if (equippedWeapon.itemClass == Item.ItemClass.Crossbow) {
                ms.shootCrossBow = true;
            } else if (equippedWeapon.itemClass == Item.ItemClass.Axe) {
                ms.swingAxe = true;
            } else if (equippedWeapon.itemClass == Item.ItemClass.Wand) {
                ms.shootWand = true;
            }
        }
        
    }

    public void playSound() {
        if (equippedWeapon != null) {
            if (equippedWeapon.itemClass == Item.ItemClass.Sword) {
                GameManager.Instance.soundManager.playSwordSwingSound();
            } else if (equippedWeapon.itemClass == Item.ItemClass.Crossbow) {
                GameManager.Instance.soundManager.playCrossbowSound();
            } else if (equippedWeapon.itemClass == Item.ItemClass.Wand) {
                GameManager.Instance.soundManager.playWandShootSound();
            } else if (equippedWeapon.itemClass == Item.ItemClass.Axe) {
                GameManager.Instance.soundManager.playAxeSwingSound();
            }
        }
    }

    public void OnStartGame()
    {
        if(ms != null)
            ms.enabled = true;
    }
}
