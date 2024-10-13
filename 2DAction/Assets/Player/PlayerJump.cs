using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float maxHeight;
    public float d = 1f;
    PlayerTransform playerTransform;

    float currentHeight;
    float jumpTime;

    bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        isGround = true;
        jumpTime = 0f;
        playerTransform = GetComponent<PlayerTransform>();
        currentHeight = transform.position.y;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (!isGround)
        {
            jumpTime = Mathf.MoveTowards(jumpTime, 1f, Time.fixedDeltaTime);
            if (jumpTime >= 1f)
            {
                currentHeight = maxHeight * (1f - (1f - Mathf.Pow(1f, d)));
                isGround = true;
                jumpTime = 0f;
                return;
            }
            currentHeight = maxHeight * (1f - (1f - Mathf.Pow(Mathf.Sin(Mathf.PI * jumpTime), d)));
            playerTransform.SetHeight(currentHeight);
        }
    }

    public void Jump()
    {
        isGround = false;
        currentHeight = transform.position.y;
    }
}
