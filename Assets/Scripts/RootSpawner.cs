using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawner : MonoBehaviour
{
    public float vineSpawnInterval;
    public float initialSpawnBuffer;
    public float attractorLookAtFactor = 0.5f;
    public float yAdj;

    private RootsAttractor attractor;
    private float spawnTimer;

    void Start()
    {
        attractor = GameManager.S.rootsAttractor.GetComponent<RootsAttractor>();
        spawnTimer = vineSpawnInterval;
    }

    void Update()
    {
        if (attractor.state == RootsAttractor.AttractorState.moving ||
            attractor.state == RootsAttractor.AttractorState.active)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0.0f)
            {
                // Reset timer
                spawnTimer = vineSpawnInterval;
                SpawnRoot();
            }
        }
        else
        {
            spawnTimer = vineSpawnInterval + initialSpawnBuffer;
        }
    }

    private void SpawnRoot()
    {
        // Get random root model
        int idx = Random.Range(0, GameManager.S.rootModels.Count);
        GameObject rootModel = GameManager.S.rootModels[idx];

        // Spawn create root
        GameObject root = Instantiate(rootModel, GameManager.S.rootsParent.transform);
        Vector3 rootPos = new(transform.position.x, transform.position.y + yAdj, transform.position.z);
        root.transform.position = rootPos;

        var rotation = Quaternion.LookRotation(GameManager.S.rootsAttractor.transform.position - transform.position);
        root.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, attractorLookAtFactor);

        // Sound
        SoundManager.S.RootSpawnSound();
    }
}
