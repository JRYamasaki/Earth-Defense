using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSoundController : MonoBehaviour 
{
    public AudioClip tankShotSound, tankExplosionSound;
    private AudioSource audioSource;

	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlayTankExplosionSound()
    {
        audioSource.clip = tankExplosionSound;
        audioSource.Play();
    }
	
    public void PlayTankShotSound()
    {
        audioSource.clip = tankShotSound;
        audioSource.Play();
    }
}
