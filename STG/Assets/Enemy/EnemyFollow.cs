using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Rigidbody2D rb;
    public EnemyGetPos enemyGetPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemyGetPos.ShiftPastPosList();
        rb.MovePosition(enemyGetPos.GetPastPos());
    }
}
