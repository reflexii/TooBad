using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource effectSource;
    public AudioSource footstepSource;
    public AudioSource hitSource;
    public AudioSource enemyDeathSource;
    public AudioSource playerDeathSource;
    public AudioSource bossSoundsSource;
    public AudioSource playerDamageSource;
    private float randomizedPitch = 1.0f;

    public AudioClip footstepSound;
    public AudioClip swordswingSound;
    public AudioClip hitSound;
    public AudioClip hitSound2;
    public AudioClip enemyDeath;
    public AudioClip playerDeath;
    public AudioClip bossDeath;
    public AudioClip bossTableBreak;
    public AudioClip playerDamaged;
    public AudioClip crossbowSound;

	
    public void playFootSteps() {
        footstepSource.clip = footstepSound;
        footstepSource.loop = true;
        footstepSource.Play();
    }

    public void playEnemyDeathSound() {
        enemyDeathSource.clip = enemyDeath;
        randomizePitch(enemyDeathSource, 0.1f);
        enemyDeathSource.Play();
    }

    public void playPlayerDeathSound() {
        playerDeathSource.clip = playerDeath;
        randomizePitch(playerDeathSource, 0.1f);
        playerDeathSource.Play();
    }
    
    public void playPlayerDamagedSound() {
        playerDamageSource.clip = playerDamaged;
        randomizePitch(playerDamageSource, 0.2f);
        playerDamageSource.Play();
    }

    public void playTableBreakSound() {
        bossSoundsSource.clip = bossTableBreak;
        bossSoundsSource.Play();
    }

    public void playBossDeathSound() {
        bossSoundsSource.clip = bossDeath;
        bossSoundsSource.Play();
    }

    public void playHitSound() {
        int random = Random.Range(0, 2);
        if (random == 0) {
            hitSource.clip = hitSound;
        } else {
            hitSource.clip = hitSound2;
        }

        randomizePitch(hitSource, 0.1f);
        hitSource.Play();
    }

    public void playSwordSwingSound() {
        effectSource.clip = swordswingSound;
        randomizePitch(effectSource, 0.1f);
        effectSource.Play();
    }

    public void playCrossbowSound() {
        effectSource.clip = crossbowSound;
        randomizePitch(effectSource, 0.1f);
        effectSource.Play();
    }

    public void randomizePitch(AudioSource source, float gap) {
        randomizedPitch = Random.Range(1 - (gap/2), 1 + (gap/2));
        source.pitch = randomizedPitch;
    }

    public void stopFootStepSound() {
        footstepSource.Stop();
    }

    public AudioSource getSource() {
        return effectSource;
    }
}
