using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJetSoundController : MonoBehaviour 
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
