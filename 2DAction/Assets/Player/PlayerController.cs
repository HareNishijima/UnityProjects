using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    Vector2 moveVector;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        moveVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVector = AxisRawInput * moveSpeed * Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        playerTransform.move(moveVector);
    }
}
