using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerTransform : MonoBehaviour
{
    PlayerController playerController;
    Controller controller;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        playerController = new PlayerController(transform.position, transform.rotation);
        controller = new Controller();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = controller.MoveInput();

        playerController = playerController.Controller(input);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = playerController.position;
        transform.rotation = playerController.quaternion;
    }
}