using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    enum JumpState { Idle, Charge, Rising, Falling };
    [SerializeField] JumpState jumpState;
    [SerializeField] bool isGround;
    [SerializeField] bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        jumpState = JumpState.Idle;
        isGround = true;
        isDead = false;
    }
    public bool IsGround()
    {
        // return jumpState == JumpState.Ground;
        return isGround;
    }
    public bool IsJumpCharge()
    {
        return jumpState == JumpState.Charge;
    }
    public bool IsJumpRising()
    {
        return jumpState == JumpState.Rising;
    }
    public bool IsJumpFalling()
    {
        return jumpState == JumpState.Falling;
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void ToGround()
    {
        // jumpState = JumpState.Ground;
        jumpState = JumpState.Idle;
        isGround = true;
    }
    public void ToJumpCharge()
    {
        jumpState = JumpState.Charge;
    }
    public void ToJumpRising()
    {
        jumpState = JumpState.Rising;
        isGround = false;
    }
    public void ToJumpFalling()
    {
        jumpState = JumpState.Falling;
    }
    public void ToDead()
    {
        isDead = true;
        GetComponent<PlayerAnimation>().ToDead();
    }
}
