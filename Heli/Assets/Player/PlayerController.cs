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
        return Quaternion.Euler(0f, 0f, 0f);
    }
}
