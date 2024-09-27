using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    Controller controller;
    Vector2 jumpVector;
    PlayerTransform playerTransform;

    public float jumpPower;
    public Vector2 maxJumpVector;
    public float jumpVectorDelta;

    void Start()
    {
        controller = new Controller();
        jumpVector = Vector2.zero;
        playerTransform = GetComponent<PlayerTransform>();
    }

    void Update()
    {
        bool fire1 = controller.GetFire1();
        if (fire1) jumpStart();
    }

    void FixedUpdate()
    {
        // jumpVectorの減衰計算
        jumpVector = Vector2.MoveTowards(jumpVector, maxJumpVector, jumpVectorDelta);


        playerTransform.move(jumpVector);
    }

    void jumpStart()
    {
        jumpVector = new Vector2(0f, jumpPower);
    }
}
