using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Rigidbody2D rb;
    public EnemyLeader enemyLeader;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.position = enemyLeader.GetPastPos();
    }
}
