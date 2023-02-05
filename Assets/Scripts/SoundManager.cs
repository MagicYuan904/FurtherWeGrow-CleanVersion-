using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Note to Luka: Template sound script, names are placeholders
    // add '//' slash comments to tell me how to assign which action to a sound
    
    public static SoundManager S; // Singleton definition

    private AudioSource audio;
    public GameObject Walking_SFX;

    [Header("Collectible Trigger Sound")]
    public AudioClip CollectTrigger_SFX; //trigger when collide with collectible

    [Header("Ambient Sound")]
    public AudioSource CityWind_Ambient; //trigger when left the cave; Fade in

    [Header("Footstep Sound")]
    public AudioClip Footstep_SFX; // trigger when moving

    [Header("Jump End Sound")]
    public AudioClip JumpEnd_SFX; // one shot, trigger after jump ended

    [Header("Root Spawn Sound")]
    public AudioClip Root_SFX; // trigger when shooting projectile spawn the root

    public AudioClip DetractorOff_SFX;
    public AudioClip DetractorOn_SFX;
    public AudioClip Attractor_SFX;


    private void Awake()
    {
        S = this; // singleton is assigned
    }

    // Start is called before the first frame update
    void Start()
    {
        // assign audio component
        audio = GetComponent<AudioSource>();
    }

    // Game/UI Sounds
    public void MakeRoundStartSound()
    {
        
    }

    // World
    public void RootSpawnSound()
    {
        audio.PlayOneShot(Root_SFX, 1.0f);
    }
    public void CollectibleSound()
    {
        audio.PlayOneShot(CollectTrigger_SFX, 1.0f);
    }


    // Player Sounds

    public void PlayerWalkingSoundOn()
    {
        Walking_SFX.SetActive(true);
    }

    public void PlayerWalkingSoundOff()
    {
        Walking_SFX.SetActive(false);
    }

    public void PlayerLandSound()
    {
        audio.PlayOneShot(JumpEnd_SFX, 1.0f);
    }

    // Action Sounds
    public void DectractorOnSound()
    {
        audio.PlayOneShot(DetractorOn_SFX, 1.0f);
    }
    public void DectractorOffSound()
    {
        audio.PlayOneShot(DetractorOff_SFX, 1.0f);
    }
    public void AttractorFireSound()
    {
        audio.PlayOneShot(Attractor_SFX, .25f);
    }


    public void StopAllSounds()
    {
        // stop ambient noise
        audio.Stop();

        // stop all child sounds
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

    }
}

