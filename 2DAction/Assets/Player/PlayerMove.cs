using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerTransform playerTransform;
    Vector2 AxisRawInput;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
    }


    void Update()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 moveVector = AxisRawInput * moveSpeed;
        playerTransform.Move(moveVector);
    }
}
