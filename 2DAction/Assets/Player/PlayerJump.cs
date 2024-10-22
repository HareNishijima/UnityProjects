using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 jumpVec;

    PlayerState playerState;
    PlayerTransform playerTransform;

    public float deltaRising;
    public float deltaFalling;
    public float minFalling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpVec = Vector2.zero;

        playerState = GetComponent<PlayerState>();
        playerTransform = GetComponent<PlayerTransform>();
    }

    public void JumpStart()
    {
        playerState.ToRising();

        jumpVec = new Vector2(0f, deltaRising);
        playerTransform.SetJumpVector(jumpVec);
    }

    public void Rising()
    {
        playerTransform.SetJumpVector(jumpVec);
    }

    public void RisingEnd()
    {
        playerState.ToFalling();
        playerTransform.SetJumpVector(jumpVec);
    }

    public void Falling()
    {
        float newJumpVecY = Mathf.Max(jumpVec.y - deltaFalling, minFalling);

        jumpVec = new Vector2(jumpVec.x, newJumpVecY);
        playerTransform.SetJumpVector(jumpVec);
    }
}
