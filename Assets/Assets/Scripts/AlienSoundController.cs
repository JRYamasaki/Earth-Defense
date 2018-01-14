using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSoundController : MonoBehaviour 
{
    public AudioClip movementSound1, movementSound2, movementSound3, movementSound4;
    public AudioSource audioSource;

    private List<AudioClip> alienMovementSounds = new List<AudioClip>();
    private int soundCounter;

	void Start () 
    {
        alienMovementSounds = new List<AudioClip>();
        soundCounter = 0;
        FillAudioList();
	}

    void FillAudioList()
    {
        alienMovementSounds.Add(movementSound1);
        alienMovementSounds.Add(movementSound2);
        alienMovementSounds.Add(movementSound3);
        alienMovementSounds.Add(movementSound4);
    }
	
	public void PlayAlienMovementSound()
    {
        audioSource.clip = alienMovementSounds[soundCounter % alienMovementSounds.Count];
        audioSource.Play();
        soundCounter++;
    }
}
