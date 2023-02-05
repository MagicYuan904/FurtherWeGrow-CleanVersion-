using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsAttractor : MonoBehaviour
{
    public enum AttractorState { off, moving, active };

    public float maxDistance;
    public float speed;
    public float activeTime;
    public AttractorState state = AttractorState.off;

    private Rigidbody rb;
    private Transform playerTransform;
    private GameObject model;
    private float activeTimer;
    private Vector3 fireDir;
    private Vector3 firePos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameManager.S.player.transform;
        activeTimer = activeTime;
        model = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        if (state == AttractorState.off)
        {
            transform.position = playerTransform.position;
        }
        else if (state == AttractorState.moving)
        {
            transform.position += speed * Time.deltaTime * fireDir;
            CheckMaxDist();
        }
        else if (state == AttractorState.active)
        {
            Countdown();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void FireAttractor()
    {
        if (state == AttractorState.off)
        {
            firePos = playerTransform.position;
            fireDir = playerTransform.forward;
            state = AttractorState.moving;
        }
    }

    private void Countdown()
    {
        activeTimer -= Time.deltaTime;
        if (activeTimer <= 0.0f)
        {
            // Reset timer
            activeTimer = activeTime;
            ResetAttractor();
        }
    }

    private void CheckMaxDist()
    {
        float dist = Vector3.Distance(firePos, transform.position);
        if (dist > maxDistance)
        {
            ResetAttractor();
            Debug.Log("Max Distance Reached!");
            // Additional partical effects
        }
    }

    private void ResetAttractor()
    {
        // Reset state
        state = AttractorState.off;
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log("Attractor Reset");

    }

    private void OnCollisionEnter(Collision collision)
    {
        state = AttractorState.active;
        Debug.Log("Collision with " + collision.gameObject.name);
    }
}
