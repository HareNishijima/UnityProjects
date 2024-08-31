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
        float angleZ = current.eulerAngles.z;
        float newAngleZ = angleZ;
        if (angleZ > 180f) newAngleZ -= 360f;

        if (input.x != 0f)
        {
            newAngleZ = -input.x * 45f;
        }
        else if (input.y != 0f)
        {
            newAngleZ = input.y * 45f;
        }
        return Quaternion.Euler(0f, 0f, newAngleZ);
    }
}
