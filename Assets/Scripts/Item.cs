using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int scoreValue = 1;
    public int ammoValue = 1;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            SoundManager.S.CollectibleSound();
            GameManager.S.scoreCount += scoreValue;
            GameManager.S.ammoCount += ammoValue;
            GameManager.S.UpdateTextUI();
            // Play sound
            Destroy(gameObject);
        }
    }
}
