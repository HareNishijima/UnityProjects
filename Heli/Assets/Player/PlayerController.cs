using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController
{
    public Vector2 position;
    public Quaternion quaternion;

    public Vector2 NewPosition(Vector2 input, Vector2 current)
    {
        float moveSpeed = 10f;

        Vector2 moveVector = input * moveSpeed;
        Vector2 movePosition = moveVector * Time.fixedDeltaTime;
        Vector2 newPosition = movePosition + current;

        return newPosition;
    }

    public Quaternion NewQuaternion(Vector2 input, Quaternion current)
    {
        return Quaternion.identity;
    }

    // ここの処理をNewPositionとNewQuaternionに移す
    void Logic(Vector2 input)
    {


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
