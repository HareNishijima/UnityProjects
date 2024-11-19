using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    enum JumpState { Ground, Charging, Rising, Falling };
    [SerializeField] JumpState jumpState;

    // Start is called before the first frame update
    void Start()
    {
        jumpState = JumpState.Ground;
    }
    public bool IsGround()
    {
        return jumpState == JumpState.Ground;
    }
    public bool ICharging()
    {
        return jumpState == JumpState.Charging;
    }
    public bool IsRising()
    {
        return jumpState == JumpState.Rising;
    }
    public bool IsFalling()
    {
        return jumpState == JumpState.Falling;
    }
    public void ToGround()
    {
        jumpState = JumpState.Ground;
    }
    public void ToCharging()
    {
        jumpState = JumpState.Charging;
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
