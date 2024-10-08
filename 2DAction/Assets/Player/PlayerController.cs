using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    PlayerAttack playerAttack;
    Vector2 AxisRawInput;

    enum State { Ready, Attack, AttackReturn };
    State state;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerAttack = GetComponent<PlayerAttack>();
        AxisRawInput = Vector2.zero;
        state = State.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (state == State.Ready && Input.GetButtonDown("Fire1"))
        {
            state = State.Attack;
            playerAttack.AttackStart();
        }
        else if (state == State.Attack && Input.GetButtonUp("Fire1"))
        {
            state = State.AttackReturn;
        }
    }

    void FixedUpdate()
    {
        if (state == State.Ready)
        {
            playerTransform.Input(AxisRawInput);
        }
        else if (state == State.Attack)
        {
            playerAttack.AttackPlay();
        }
        else if (state == State.AttackReturn)
        {
            playerAttack.AttackEnd();
        }

    }
}
