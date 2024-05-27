using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{

    GameObject player;
    Rigidbody2D rb;

    public float maxHomingAngle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(transform.right.x, transform.right.y) * -1f;
        rb.MovePosition(rb.position + moveVec * speed * Time.deltaTime);
    }
}
