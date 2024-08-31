using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerTransform : MonoBehaviour
{
    Controller controller;
    PlayerController playerController;
    Vector2 newPosition;
    Quaternion newQuaternion;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        playerController = new PlayerController();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = controller.AdjustedInput();

        newPosition = playerController.NewPosition(moveInput, rigidbody2d.position);
        newQuaternion = playerController.NewQuaternion(moveInput, transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = newPosition;
        transform.rotation = newQuaternion;
    }
}