using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    PlayerJump playerJump;
    Vector2 AxisRawInput;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerState = GetComponent<PlayerState>();
        playerJump = GetComponent<PlayerJump>();
        AxisRawInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // ジャンプ
        if (playerState.IsGround() && Input.GetButtonDown("Jump"))
        {
            playerJump.Jump(AxisRawInput);
        }
    }

    void FixedUpdate()
    {
        if (playerState.IsGround())
        {
            playerTransform.Input(AxisRawInput);
        }
    }
}
