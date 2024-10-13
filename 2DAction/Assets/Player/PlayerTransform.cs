using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public float moveSpeed = 10f;

    Vector2 moveVector;
    Vector2 jumpVector;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x + moveVector.x, jumpVector.y));

        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
    }

    public void Input(Vector2 axisRawInput)
    {
        Vector2 HorizontalRawInput = new Vector2(axisRawInput.x, 0f);
        moveVector = HorizontalRawInput * moveSpeed * Time.fixedDeltaTime;
    }

    public void SetHeight(float height)
    {
        jumpVector = new Vector2(0f, height);
    }
}
