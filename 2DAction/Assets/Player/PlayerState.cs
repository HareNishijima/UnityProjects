using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum State { Ready, Attack, AttackReturn };
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Ready;
    }

    public bool IsReady()
    {
        return state == State.Ready;
    }

    public bool IsAttack()
    {
        return state == State.Attack;
    }

    public bool IsAttackReturn()
    {
        return state == State.AttackReturn;
    }

    public void ToReady()
    {
        state = State.Ready;
    }

    public void ToAttack()
    {
        state = State.Attack;
    }

    public void ToAttackReturn()
    {
        state = State.AttackReturn;
    }
}
