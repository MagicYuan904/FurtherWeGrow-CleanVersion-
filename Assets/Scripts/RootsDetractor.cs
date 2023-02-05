using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsDetractor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Root"))
        {
            if (other.transform.GetComponent<GrowVinesScript>())
            {
                other.transform.GetComponent<GrowVinesScript>().DeleteVines();
                Debug.Log("Detracting Root!");
            }
        }
    }
}
