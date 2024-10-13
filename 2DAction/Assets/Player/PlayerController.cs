using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    PlayerAttack playerAttack;
    PlayerJump playerJump;
    Vector2 AxisRawInput;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerAttack = GetComponent<PlayerAttack>();
        playerState = GetComponent<PlayerState>();
        playerJump = GetComponent<PlayerJump>();
        AxisRawInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 移動
        if (playerState.IsReady() && Input.GetButtonDown("Fire1"))
        {
            playerAttack.AttackStart(AxisRawInput);
        }
        else if (playerState.IsAttack() && Input.GetButtonUp("Fire1"))
        {
            playerState.ToAttackReturn();
        }

        // 攻撃
        if (playerState.IsGround() && Input.GetButtonDown("Jump"))
        {
            playerJump.Jump(AxisRawInput);
        }
    }

    void FixedUpdate()
    {
        if (playerState.IsGround() && playerState.IsReady())
        {
            playerTransform.Input(AxisRawInput);
        }
        else if (playerState.IsAttack())
        {
            playerAttack.AttackPlay();
        }
        else if (playerState.IsAttackReturn())
        {
            playerAttack.AttackEnd();
        }
    }
}
