using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerTransform playerTransform;
    PlayerRenderer playerRenderer;
    Vector2 AxisRawInput;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerRenderer = GetComponent<PlayerRenderer>();
    }


    public void MoveInput()
    {
        AxisRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 入力方向に応じてスプライトの方向も変更
        if (AxisRawInput.x > 0f)
        {
            playerRenderer.DirectionRight(true);
        }
        else if (AxisRawInput.x < 0f)
        {
            playerRenderer.DirectionRight(false);
        }

        Vector2 moveVector = AxisRawInput * moveSpeed;
        playerTransform.SetMove(new Vector2(moveVector.x, 0f));
    }
}
