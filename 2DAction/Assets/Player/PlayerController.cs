using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    PlayerAttack playerAttack;
    Vector2 AxisRawInput;
    PlayerAttackState playerAttackState;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAttackState = GetComponent<PlayerAttackState>();
        AxisRawInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (playerAttackState.IsReady() && Input.GetButtonDown("Fire1"))
        {
            playerAttackState.ToAttack();
            playerAttack.AttackStart();
        }
        else if (playerAttackState.IsAttack() && Input.GetButtonUp("Fire1"))
        {
            playerAttackState.ToAttackReturn();
        }
    }

    void FixedUpdate()
    {
        if (playerAttackState.IsReady())
        {
            playerTransform.Input(AxisRawInput);
        }
        else if (playerAttackState.IsAttack())
        {
            playerAttack.AttackPlay();
        }
        else if (playerAttackState.IsAttackReturn())
        {
            playerAttack.AttackEnd();
        }

    }
}
