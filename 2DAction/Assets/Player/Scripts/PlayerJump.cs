using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Vector2 jumpVector;

    PlayerState playerState;
    PlayerTransform playerTransform;

    public float startRising;
    public float maxRisingTime;
    public float deltaFalling;
    public float minFalling;

    float risingTime;

    // Start is called before the first frame update
    void Start()
    {
        jumpVector = Vector2.zero;
        playerState = GetComponent<PlayerState>();
        playerTransform = GetComponent<PlayerTransform>();
        risingTime = 0f;
    }

    public void JumpInput()
    {
        // ジャンプ開始
        if (playerState.IsGround() && Input.GetButtonDown("Jump"))
        {
            playerState.ToRising();
            risingTime = 0f;

            jumpVector = new Vector2(0f, startRising);
            playerTransform.Jump(jumpVector);
        }
        // ボタン長押しでジャンプ上昇中
        if (playerState.IsRising() && Input.GetButton("Jump"))
        {
            risingTime += Time.deltaTime;
            playerTransform.Jump(jumpVector);
        }
        // 上昇中にボタンを離す、もしくは一定時間経過すると落下開始
        if (playerState.IsRising() && Input.GetButtonUp("Jump") || risingTime >= maxRisingTime)
        {
            playerState.ToFalling();
        }
        // 落下中
        if (playerState.IsFalling())
        {
            float newJumpVectorY = Mathf.Max(jumpVector.y - deltaFalling, minFalling);

            jumpVector = new Vector2(0f, newJumpVectorY);
            playerTransform.Jump(jumpVector);
        }
    }
}
