using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float maxHeight;
    public float d = 1f;
    PlayerTransform playerTransform;
    PlayerState playerState;

    float currentHeight;
    float jumpTime;
    float moveX;

    // Start is called before the first frame update
    void Start()
    {
        jumpTime = 0f;
        playerTransform = GetComponent<PlayerTransform>();
        playerState = GetComponent<PlayerState>();
        currentHeight = transform.position.y;
    }

    void FixedUpdate()
    {
        if (!playerState.IsGround())
        {
            jumpTime = Mathf.MoveTowards(jumpTime, 1f, Time.fixedDeltaTime);
            if (jumpTime >= 1f)
            {
                currentHeight = maxHeight * (1f - (1f - Mathf.Pow(1f, d)));
                playerState.ToGround();
                jumpTime = 0f;
                return;
            }
            currentHeight = maxHeight * (1f - (1f - Mathf.Pow(Mathf.Sin(Mathf.PI * jumpTime), d)));
            playerTransform.SetHeight(currentHeight);
            playerTransform.Input(new Vector2(moveX, 0f));
        }
    }

    public void Jump(Vector2 AxisRawInput)
    {
        moveX = AxisRawInput.x;
        currentHeight = transform.position.y;
        playerState.LeaveGround();
    }
}
