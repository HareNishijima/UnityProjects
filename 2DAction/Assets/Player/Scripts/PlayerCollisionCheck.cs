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
        // 接地状態か落下状態でしか接地判定を行わない
        if (!(playerState.IsGround() || playerState.IsFalling())) return;

        bool isTouching = rb.IsTouching(contactFilter2D);

        // 接地状態から落下
        if (playerState.IsGround() && !isTouching)
        {
            playerState.ToFalling();
        }
        // 落下状態から接地
        else if (playerState.IsFalling() && isTouching)
        {
            playerState.ToGround();
        }
    }
}
