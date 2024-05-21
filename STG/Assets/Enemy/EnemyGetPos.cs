using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetPos : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetPos()
    {
        return rb.position;
    }
}
