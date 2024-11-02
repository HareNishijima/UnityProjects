using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    [SerializeField] ContactFilter2D contactFilter2D;
    Rigidbody2D rb;
    PlayerState playerState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    public void CheckGround()
    {
        if (!playerState.IsFalling()) return;

        bool isTouching = rb.IsTouching(contactFilter2D);

        if (isTouching)
        {
            playerState.ToGround();
        }
    }
}
