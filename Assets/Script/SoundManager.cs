using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip walksandSound, jumpSound, attackSound, war;
    static AudioSource audioSource;


    private void Start()
    {
        walksandSound = Resources.Load<AudioClip>("walk");
        jumpSound = Resources.Load<AudioClip>("jump");
        attackSound = Resources.Load<AudioClip>("attackgrunt");
        war = Resources.Load<AudioClip>("war");
        audioSource = GetComponent<AudioSource>();
        Noise();
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "walksand":
            audioSource.clip = walksandSound;
            audioSource.Play();
            break;
            case "jump":
            audioSource.PlayOneShot(jumpSound);
            // audioSource.clip = jumpSound;
            // audioSource.Play();            
            break;
            case "attack":
            audioSource.clip = attackSound;
            audioSource.Play();
            break;
            default:
            audioSource.Stop();
            break;
        }
    }
    public void Noise()
    {
        audioSource.clip = war;
        audioSource.Play();
    }
}
