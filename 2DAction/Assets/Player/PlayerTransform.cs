using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void move(Vector2 moveVector)
    {
        rigidbody2D.MovePosition(rigidbody2D.position + moveVector);
    }
}
