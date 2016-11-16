﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    private float minimumPitch = 0.95f;
    private float maximumPitch = 1.05f;
    public AudioSource effectSource;
    public AudioSource footstepSource;
    private float randomizedPitch = 1.0f;

    public AudioClip footstepSound;
    public AudioClip swordswingSound;
    public AudioClip hitSound;
    public AudioClip hitSound2;

	
    public void playFootSteps() {
        footstepSource.clip = footstepSound;
        footstepSource.loop = true;
        footstepSource.Play();
    }

    public void playHitSound() {
        int random = Random.Range(0, 2);
        if (random == 0) {
            effectSource.clip = hitSound;
        } else {
            effectSource.clip = hitSound2;
        }

        randomizePitch();
        effectSource.Play();
    }

    public void playSwordSwingSound() {
        effectSource.clip = swordswingSound;
        randomizePitch();
        effectSource.Play();
    }

    public void randomizePitch() {
        randomizedPitch = Random.Range(minimumPitch, maximumPitch);
        effectSource.pitch = randomizedPitch;
    }

    public void stopFootStepSound() {
        footstepSource.Stop();
    }

    public AudioSource getSource() {
        return effectSource;
    }
}