using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerTransform : MonoBehaviour
{
    Controller controller;
    PlayerController playerController;

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
        Vector2 moveInput = controller.MoveInput();

        Vector2 newPosition = playerController.NewPosition(moveInput);
        Quaternion newQuaternion = playerController.NewQuaternion(moveInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // rigidbody2d.position = 新しい座標
        // transform.rotation = 新しいクォータニオン
    }
}