using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public void move(Vector2 moveVector)
    {
        transform.position = transform.position + new Vector3(moveVector.x, moveVector.y, 0f);
    }
}
