using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public Vector2 position;
    public Quaternion quaternion;
    float speed = 10f;

    public Vector2 NewPosition(Vector2 input)
    {
        return Vector2.zero;
    }

    public Quaternion NewQuaternion(Vector2 input)
    {
        return Quaternion.identity;
    }

    // ここの処理をNewPositionとNewQuaternionに移す
    void Logic(Vector2 input)
    {
        // 入力値から移動するベクトルを計算し、新しい座標を更新
        Vector2 moveVec = input * speed;
        Vector2 newPosition = moveVec * Time.deltaTime + position;

        float angleZ = quaternion.eulerAngles.z;
        if (angleZ > 180f) angleZ -= 360f;
        float newAngleZ = angleZ;
        if (input.x != 0f)
        {
            newAngleZ = -input.x * 45f;
        }
        else if (input.y != 0f)
        {
            newAngleZ = input.y * 45f;
        }
        Quaternion qua = Quaternion.Euler(0f, 0f, newAngleZ);
    }

    float Mapping(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return Mathf.Lerp(outMin, outMax, Mathf.InverseLerp(inMin, inMax, value));
    }
}
