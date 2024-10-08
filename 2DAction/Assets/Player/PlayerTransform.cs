using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public float moveSpeed = 10f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Input(Vector2 AxisRawInput)
    {
        Vector2 moveVector = AxisRawInput * moveSpeed * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(rigidbody2D.position + moveVector);
    }
}
