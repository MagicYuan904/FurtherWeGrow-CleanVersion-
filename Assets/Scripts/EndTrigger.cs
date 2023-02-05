using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public float waitTime = 5f;
    public GameObject whiteFade;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            // Go to next scene
            StartCoroutine(GoToEndScene());

            // Play sound
        }
    }

    private IEnumerator GoToEndScene()
    {
        whiteFade.SetActive(true); 
        yield return new WaitForSeconds(waitTime);
        Cursor.lockState = CursorLockMode.None; // Good idea here?
        LevelManager.S.LoadNextScene();
    }
}
