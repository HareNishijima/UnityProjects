using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerTransform : MonoBehaviour
{
    Controller controller;
    PlayerController playerController;
    Vector3 newPosition;
    Quaternion newQuaternion;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        playerController = new PlayerController();
    }

    void Update()
    {
        Vector2 moveInput = controller.MoveInput();

        newPosition = playerController.NewPosition(moveInput, transform.position);
        newQuaternion = playerController.NewQuaternion(moveInput, transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = newPosition;
        transform.rotation = newQuaternion;
    }
}