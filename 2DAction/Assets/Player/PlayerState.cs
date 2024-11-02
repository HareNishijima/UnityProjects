using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    enum AttackState { Ready, Attack };
    [SerializeField] AttackState attackstate;

    enum JumpState { Ground, Rising, Falling };
    [SerializeField] JumpState jumpState;

    // Start is called before the first frame update
    void Start()
    {
        attackstate = AttackState.Ready;
        jumpState = JumpState.Ground;
    }

    public bool IsReady()
    {
        return attackstate == AttackState.Ready;
    }

    public bool IsAttack()
    {
        return attackstate == AttackState.Attack;
    }

    public bool IsGround()
    {
        return jumpState == JumpState.Ground;
    }

    public bool IsRising()
    {
        return jumpState == JumpState.Rising;
    }

    public bool IsFalling()
    {
        return jumpState == JumpState.Falling;
    }

    public void ToReady()
    {
        attackstate = AttackState.Ready;
    }

    public void ToAttack()
    {
        attackstate = AttackState.Attack;
    }

    public void ToGround()
    {
        jumpState = JumpState.Ground;
    }

    public void ToRising()
    {
        jumpState = JumpState.Rising;
    }

    public void ToFalling()
    {
        jumpState = JumpState.Falling;
    }
}
