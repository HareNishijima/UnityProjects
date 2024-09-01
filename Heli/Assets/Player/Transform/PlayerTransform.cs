using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerTransform : MonoBehaviour
{
    Controller controller;
    PlayerTransformController playerTransformController;
    Vector2 newPosition;
    Quaternion newQuaternion;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        playerTransformController = new PlayerTransformController();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 rawInput = controller.RawInput();
        Vector2 moveInput = controller.AdjustedInput();

        newPosition = playerTransformController.NewPosition(moveInput, rigidbody2d.position);
        newQuaternion = playerTransformController.NewQuaternion(rawInput, transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = newPosition;
        transform.rotation = newQuaternion;
    }
}