using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float maxHeight;
    public float sinCurveDistortion = 1f;
    PlayerTransform playerTransform;
    PlayerState playerState;
    float currentHeight;
    float jumpTime;
    float jumpMoveX;

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
        if (playerState.IsGround()) return;

        jumpTime = Mathf.MoveTowards(jumpTime, 1f, Time.fixedDeltaTime);

        // ジャンプ開始からjumpTime秒経過したら着地とする
        if (jumpTime >= 1f)
        {
            jumpTime = 0f;
            currentHeight = maxHeight * (1f - (1f - Mathf.Pow(1f, sinCurveDistortion)));
            playerState.ToGround();
            return;
        }
        currentHeight = maxHeight * (1f - (1f - Mathf.Pow(Mathf.Sin(Mathf.PI * jumpTime), sinCurveDistortion)));
        playerTransform.SetHeight(currentHeight);
        playerTransform.Input(new Vector2(jumpMoveX, 0f));

    }

    public void Jump(Vector2 AxisRawInput)
    {
        jumpMoveX = AxisRawInput.x;
        currentHeight = transform.position.y;
        playerState.LeaveGround();
    }
}
