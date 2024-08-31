using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerTransform : MonoBehaviour
{
    Controller controller;
    PlayerController playerController;
    Transform newTransform;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        playerController = new PlayerController();
    }

    void Update()
    {
        Vector2 moveInput = controller.MoveInput();

        Vector2 newPosition = playerController.NewPosition(moveInput, transform.position);
        Quaternion newQuaternion = playerController.NewQuaternion(moveInput, transform.rotation);

        newTransform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        newTransform.rotation = newQuaternion;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = newTransform.position;
        transform.rotation = newTransform.rotation;
    }
}