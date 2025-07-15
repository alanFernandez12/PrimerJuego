using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shot;
    public AudioClip hit;
    public AudioClip selectMenu;
    public AudioClip explosion;
    public AudioClip heal;
    public AudioClip diePj;

    public void playShot()
    {
        audioSource.PlayOneShot(shot);
    }
    
    public void playHit()
    {
        audioSource.PlayOneShot(hit);
    }

    public void SelectOption()
    {
        audioSource.PlayOneShot(selectMenu);
    }
    public void enemyExplosion()
    {
        audioSource.PlayOneShot(explosion);
    }

    public void playHeal()
    {
        audioSource.PlayOneShot(heal);
    }

    public void playPjDie()
    {
        audioSource.PlayOneShot(diePj);
    }
}
