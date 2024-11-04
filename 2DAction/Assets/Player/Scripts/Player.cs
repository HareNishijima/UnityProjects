using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    PlayerTransform playerTransform;
    PlayerCollisionCheck playerCollisionCheck;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerCollisionCheck = GetComponent<PlayerCollisionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform.Move();
    }
}
