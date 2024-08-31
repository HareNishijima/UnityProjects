using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController
{
    public Vector2 position;
    public Quaternion quaternion;

    public Vector2 NewPosition(Vector2 adjustedInput, Vector2 current)
    {
        float moveSpeed = 10f;

        Vector2 moveVector = adjustedInput * moveSpeed;
        Vector2 movePosition = moveVector * Time.fixedDeltaTime;
        Vector2 newPosition = movePosition + current;

        return newPosition;
    }

    public Quaternion NewQuaternion(Vector2 rawInput, Quaternion current)
    {
        // 1秒でプレイヤーが180度回転するスピード
        float angleSpeed = 180f;

        // angleZ = -180 ~ 180
        float angleZ = current.eulerAngles.z;
        if (angleZ > 180f) angleZ -= 360f;

        float newAngleZ = 0f;
        if (rawInput.x == 0f && rawInput.y == 0f)
        {
            // キーを入力していないときは0度に近づく
            newAngleZ = -Mathf.Sign(angleZ) * angleSpeed * Time.fixedDeltaTime + angleZ;
            if (Mathf.Sign(angleZ) != Mathf.Sign(newAngleZ)) newAngleZ = 0f;
        }
        else if (rawInput.y != 0f)
        {
            // 上方向への入力で角度が増加、下方向の入力で角度が減少する
            newAngleZ = Mathf.Sign(rawInput.y) * angleSpeed * Time.fixedDeltaTime + angleZ;
        }
        else if (rawInput.y == 0f)
        {
            // 上下方向へ入力していないときに限り、右方向の入力で角度が減少、左方向の入力で角度が増加する
            newAngleZ = -Mathf.Sign(rawInput.x) * angleSpeed * Time.fixedDeltaTime + angleZ;
        }

        newAngleZ = Mathf.Clamp(newAngleZ, -45f, 45f);
        return Quaternion.Euler(0f, 0f, newAngleZ);
    }
}
