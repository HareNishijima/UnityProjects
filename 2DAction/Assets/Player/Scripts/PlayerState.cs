using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    enum JumpState { Ground, Charge, Rising, Falling };
    [SerializeField] JumpState jumpState;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        jumpState = JumpState.Ground;
        isDead = false;
    }
    public bool IsGround()
    {
        return jumpState == JumpState.Ground;
    }
    public bool IsCharge()
    {
        return jumpState == JumpState.Charge;
    }
    public bool IsRising()
    {
        return jumpState == JumpState.Rising;
    }
    public bool IsFalling()
    {
        return jumpState == JumpState.Falling;
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void ToGround()
    {
        jumpState = JumpState.Ground;
    }
    public void ToCharge()
    {
        jumpState = JumpState.Charge;
    }
    public void ToRising()
    {
        jumpState = JumpState.Rising;
    }
    public void ToFalling()
    {
        jumpState = JumpState.Falling;
    }
    public void ToDead()
    {
        isDead = true;
        GetComponent<PlayerAnimation>().ToDead();
    }
}
