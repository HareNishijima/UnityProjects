using System;
using UnityEditor;
using UnityEngine;

public class PlayerTransformController
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
        // プレイヤーの角度スピード(1秒間に270度回転するスピード)
        float deltaAngle = 270f * Time.fixedDeltaTime;

        // プレイヤーの角度を取得し、0 ~ 360から-180 ~ 180に変換
        float angleZ = current.eulerAngles.z;
        if (angleZ > 180f) angleZ -= 360f;

        // キー入力で角度を変更
        float newAngleZ = 0f;
        if (rawInput.y != 0f)
        {
            // 上方向の入力で角度が増加、下方向の入力で角度が減少する
            newAngleZ = Mathf.MoveTowards(angleZ, Math.Sign(rawInput.y) * 45f, deltaAngle);
        }
        else
        {
            // キーを入力していなければ、未操作時は0度に近づく
            newAngleZ = Mathf.MoveTowards(angleZ, 0f, deltaAngle);
        }

        return Quaternion.Euler(0f, 0f, newAngleZ);
    }
}
