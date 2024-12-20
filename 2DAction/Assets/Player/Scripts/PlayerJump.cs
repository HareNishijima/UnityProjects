using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Vector2 jumpVector;
    PlayerState playerState;
    PlayerTransform playerTransform;
    PlayerPhysics playerPhysics;

    public float startRisingSpeed;
    public float deltaCharge;
    public float maxCharge;

    float charge;

    // Start is called before the first frame update
    void Start()
    {
        jumpVector = Vector2.zero;
        playerState = GetComponent<PlayerState>();
        playerTransform = GetComponent<PlayerTransform>();
        playerPhysics = GetComponent<PlayerPhysics>();
        charge = 0f;
    }

    public void JumpInput()
    {
        // ジャンプタメ開始
        if (Input.GetButtonDown("Jump"))
        {
            playerState.ToJumpCharge();
            charge = 0f;
        }
        // ジャンプタメ中
        if (Input.GetButton("Jump") && playerState.IsJumpCharge())
        {
            charge = Mathf.MoveTowards(charge, maxCharge, deltaCharge * Time.deltaTime);
        }
        // ジャンプタメ解除
        if (Input.GetButtonUp("Jump") && playerState.IsJumpCharge())
        {
            playerState.ToJumpRising();
            jumpVector = new Vector2(0f, startRisingSpeed);
        }
        // 上昇
        if (playerState.IsJumpRising() && charge >= 0f)
        {
            charge -= deltaCharge * Time.deltaTime;

            playerPhysics.SetPhycisVector(jumpVector);
        }
        // 下降開始
        if (playerState.IsJumpRising() && charge < 0f)
        {
            playerState.ToJumpFalling();
        }
    }

    public void JumpVectorSetZero()
    {
        jumpVector = Vector2.zero;
    }
}
