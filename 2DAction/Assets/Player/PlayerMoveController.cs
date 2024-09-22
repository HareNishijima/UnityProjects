using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{

    Controller controller;
    PlayerTransform playerTransform;
    Vector2 moveVector;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        playerTransform = GetComponent<PlayerTransform>();
        moveVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 AxisRawInput = controller.GetAxisRaw();
        moveVector = AxisRawInput * moveSpeed * Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        playerTransform.move(moveVector);
    }
}
