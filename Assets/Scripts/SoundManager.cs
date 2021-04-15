using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource run;

    public static AudioClip impactHit;
    public static AudioClip runningSound;
    public static AudioClip deathSound;
    public static AudioClip powerUpSound;

    public static Queue<GameObject> destroyQ = new Queue<GameObject>();

    public AudioClip _impactHit;
    public AudioClip _runningSound;
    public AudioClip _deathSound;
    public AudioClip _powerUpSound;

    void Start()
    {
        //Setter for static variable
        impactHit = _impactHit;
        runningSound = _runningSound;
        deathSound = _deathSound;
        powerUpSound = _powerUpSound;

        playRun();
    }

    public static void playRun()
    {
        //Running Loop Variables
        GameObject soundObject = new GameObject("runLoopSound");
        run = soundObject.AddComponent<AudioSource>();

        //Running Sound Settings
        run.clip = runningSound;
        run.pitch = 0.85f;
        run.loop = true;
        run.Play();
    }

    public static void playHit()
    {
        //Destroy sound object
        if (destroyQ.Count != 0) { Destroy(destroyQ.Dequeue()); }


        //Creates an object to act as AudioSource
        GameObject soundObject = new GameObject("sound");
        AudioSource clip = soundObject.AddComponent<AudioSource>();

        //Enqueues it for later destruction
        destroyQ.Enqueue(soundObject);

        //Actually plays it
        clip.volume = 0.20f;
        clip.PlayOneShot(impactHit);
    }

    public static void playPowerUp()
    {
        //Destroy sound object
        if (destroyQ.Count != 0) { Destroy(destroyQ.Dequeue()); }


        //Creates an object to act as AudioSource
        GameObject soundObject = new GameObject("sound");
        AudioSource clip = soundObject.AddComponent<AudioSource>();

        //Enqueues it for later destruction
        destroyQ.Enqueue(soundObject);

        //Actually plays it
        clip.volume = 0.30f;
        clip.PlayOneShot(powerUpSound);
    }

    public static void playDeath()
    {
        //Destroy sound object
        if (destroyQ.Count != 0) { Destroy(destroyQ.Dequeue()); }


        //Creates an object to act as AudioSource
        GameObject soundObject = new GameObject("sound");
        AudioSource clip = soundObject.AddComponent<AudioSource>();

        //Enqueues it for later destruction
        destroyQ.Enqueue(soundObject);

        //Actually plays it
        clip.PlayOneShot(deathSound);
    }
}
