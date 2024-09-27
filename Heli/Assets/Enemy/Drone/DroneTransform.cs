using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 moveVec = transform.right * moveSpeed;
        rigidbody2d.position += moveVec * Time.fixedDeltaTime;
    }
}
