using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 position;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(0f,0f);
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = position;
    }
}
