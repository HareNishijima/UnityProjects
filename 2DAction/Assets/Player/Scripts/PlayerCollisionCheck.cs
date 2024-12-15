using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    [SerializeField] ContactFilter2D topFilter;
    [SerializeField] ContactFilter2D bottomFilter;
    Rigidbody2D rb;
    PlayerState playerState;
    PlayerJump playerJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
        playerJump = GetComponent<PlayerJump>();
    }

    public void CheckHeadHit()
    {
        // 接地状態では判定を行わない = 空中のみ判定を行う
        if (playerState.IsGround()) return;

        bool isTouching = rb.IsTouching(topFilter);

        if (isTouching)
        {
            playerJump.JumpVectorSetZero();
            playerState.ToJumpFalling();
        }
    }

    public void CheckGround()
    {
        // 接地状態か落下状態でしか接地判定を行わない
        if (!(playerState.IsGround() || playerState.IsJumpFalling())) return;

        bool isTouching = rb.IsTouching(bottomFilter);

        // 接地状態から落下
        if (playerState.IsGround() && !isTouching)
        {
            playerState.LeaveGround();
        }
        // 落下状態から接地
        else if (playerState.IsJumpFalling() && isTouching)
        {
            playerState.ToGround();
        }
    }
}
