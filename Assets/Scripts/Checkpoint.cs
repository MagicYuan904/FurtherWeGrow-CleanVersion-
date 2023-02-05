using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material disactiveMat;
    public Material activeMat;

    private Renderer r;
    private Renderer child_r;

    void Start()
    {
        r = GetComponent<Renderer>();
        child_r = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        if (GameManager.S.lastCheckpoint) GameManager.S.lastCheckpoint.GetComponent<Checkpoint>().DisactivateCheckpoint();
        GameManager.S.lastCheckpoint = gameObject;
        r.material = activeMat;
        child_r.material = activeMat;
        Debug.Log("New Checkpoint Activate");
    }

    public void DisactivateCheckpoint()
    {
        r.material = disactiveMat;
        child_r.material = disactiveMat;
    }
}
