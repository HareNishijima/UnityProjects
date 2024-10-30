using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 jumpVector;

    PlayerState playerState;
    PlayerTransform playerTransform;

    public float startRising;
    public float deltaRising;
    public float deltaFalling;
    public float minFalling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpVector = Vector2.zero;
        playerState = GetComponent<PlayerState>();
        playerTransform = GetComponent<PlayerTransform>();
    }

    void Update()
    {
        // ジャンプ開始
        if (playerState.IsGround() && Input.GetButtonDown("Jump"))
        {
            playerState.ToRising();

            jumpVector = new Vector2(0f, startRising);
        }
        // ボタン長押しでジャンプ上昇中
        if (playerState.IsRising() && Input.GetButton("Jump"))
        {
            jumpVector -= new Vector2(0f, deltaRising);
        }
        // 上昇中にボタンを離すと落下開始
        if (playerState.IsRising() && Input.GetButtonUp("Jump"))
        {
            playerState.ToFalling();
        }
        // 落下中
        if (playerState.IsFalling())
        {
            float newJumpVectorY = Mathf.Max(jumpVector.y - deltaFalling, minFalling);

            jumpVector = new Vector2(0f, newJumpVectorY);
        }
    }

    void FixedUpdate()
    {
        playerTransform.Jump(jumpVector);
    }
}
