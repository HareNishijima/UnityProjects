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
            newAngleZ = -Mathf.Sign(angleZ) * angleSpeed * Time.fixedDeltaTime + angleZ;
            if (Mathf.Sign(angleZ) != Mathf.Sign(newAngleZ)) newAngleZ = 0f;
        }
        else
        {
            newAngleZ = Mathf.Sign(rawInput.y) * angleSpeed * Time.fixedDeltaTime + angleZ;
        }

        newAngleZ = Mathf.Clamp(newAngleZ, -45f, 45f);
        return Quaternion.Euler(0f, 0f, newAngleZ);
    }
}
