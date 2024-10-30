using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerJump playerJump;
    Vector2 AxisRawInput;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponent<PlayerState>();
        playerJump = GetComponent<PlayerJump>();
        AxisRawInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // ジャンプ開始
        if (playerState.IsGround() && Input.GetButtonDown("Jump"))
        {
            playerJump.JumpStart();
        }
        // ボタン長押しでジャンプ上昇中
        if (playerState.IsRising() && Input.GetButton("Jump"))
        {
            playerJump.Rising();
        }
        // 上昇中にボタンを離すと落下開始(?)
        if (playerState.IsRising() && Input.GetButtonUp("Jump"))
        {
            playerJump.RisingEnd();
        }
        if (playerState.IsFalling())
        {
            playerJump.Falling();
        }
    }
}
