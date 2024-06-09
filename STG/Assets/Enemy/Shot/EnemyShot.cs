using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2(-transform.right.x, -transform.right.y) * speed;
        rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
    }
}
