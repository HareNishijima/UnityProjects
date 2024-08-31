using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    Controller controller;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = new PlayerTransform(transform.position, transform.rotation);
        controller = new Controller();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = controller.MoveInput();

        playerTransform = playerTransform.Controller(input);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = playerTransform.position;
        transform.rotation = playerTransform.quaternion;
    }
}
