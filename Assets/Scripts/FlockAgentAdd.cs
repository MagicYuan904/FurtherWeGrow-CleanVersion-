using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAgentAdd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Spawn at player
        transform.position = GameManager.S.player.transform.position;
    }
}
