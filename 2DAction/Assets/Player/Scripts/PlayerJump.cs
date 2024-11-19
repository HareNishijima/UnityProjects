using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Vector2 jumpVector;
    PlayerState playerState;
    PlayerTransform playerTransform;

    public float startRisingSpeed;
    public float deltaFallingSpeed;
    public float minFallingSpeed;
    public float deltaCharge;
    public float maxCharge;

    float charge;

    // Start is called before the first frame update
    void Start()
    {
        jumpVector = Vector2.zero;
        playerState = GetComponent<PlayerState>();
        playerTransform = GetComponent<PlayerTransform>();
        charge = 0f;
    }

    public void JumpInput()
    {
        // ジャンプタメ開始
        if (Input.GetButtonDown("Jump"))
        {
            playerState.ToCharge();
            charge = 0f;
            jumpVector = new Vector2(0f, startRisingSpeed);
        }
        // ジャンプタメ中
        if (Input.GetButton("Jump") && playerState.IsCharge())
        {
            charge = Mathf.MoveTowards(charge, maxCharge, deltaCharge * Time.deltaTime);
        }
        // ジャンプタメ解除
        if (Input.GetButtonUp("Jump") && playerState.IsCharge())
        {
            playerState.ToRising();
        }
        // 上昇
        if (playerState.IsRising() && charge >= 0f)
        {
            charge -= deltaCharge * Time.deltaTime;
            playerTransform.Jump(jumpVector);
        }
        // 下降開始
        if (playerState.IsRising() && charge < 0f)
        {
            playerState.ToFalling();
        }
        // 落下中
        if (playerState.IsFalling())
        {
            float newJumpVectorY = Mathf.Max(jumpVector.y - deltaFallingSpeed, minFallingSpeed);

            jumpVector = new Vector2(0f, newJumpVectorY);
            playerTransform.Jump(jumpVector);
        }
        // 接地中
        if (playerState.IsGround())
        {
            jumpVector = Vector2.zero;
        }
    }

    public void JumpVectorSetZero()
    {
        jumpVector = Vector2.zero;
    }
}
