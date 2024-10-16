using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    enum AttackState { Ready, Attack, AttackReturn };
    AttackState attackstate;
    bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        attackstate = AttackState.Ready;
        isGround = true;
    }

    public bool IsReady()
    {
        return attackstate == AttackState.Ready;
    }

    public bool IsAttack()
    {
        return attackstate == AttackState.Attack;
    }

    public bool IsAttackReturn()
    {
        return attackstate == AttackState.AttackReturn;
    }

    public bool IsGround()
    {
        return isGround;
    }

    public void ToReady()
    {
        attackstate = AttackState.Ready;
    }

    public void ToAttack()
    {
        attackstate = AttackState.Attack;
    }

    public void ToAttackReturn()
    {
        attackstate = AttackState.AttackReturn;
    }

    public void ToGround()
    {
        isGround = true;
    }

    public void LeaveGround()
    {
        isGround = false;
    }
}
