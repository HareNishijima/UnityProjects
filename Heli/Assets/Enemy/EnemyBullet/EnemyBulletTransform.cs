using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTransform : MonoBehaviour
{

    float moveSpeed;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 40f;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVec = transform.right * moveSpeed;
        rigidbody2d.position += moveVec * Time.fixedDeltaTime;
    }
}
