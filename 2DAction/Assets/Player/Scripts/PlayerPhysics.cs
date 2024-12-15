using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    Vector2 physicsVector;
    PlayerState playerState;
    PlayerTransform playerTransform;

    public float deltaFallingSpeed;
    public float minFallingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        physicsVector = Vector2.zero;
        playerState = GetComponent<PlayerState>();
        playerTransform = GetComponent<PlayerTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.IsGround())
        {
            // 接地
            physicsVector = Vector2.zero;
        }
        else if (!playerState.IsJumpRising())
        {
            // 落下かつジャンプ上昇中でなければ落下
            float newphysicsVectorY = Mathf.Max(physicsVector.y - deltaFallingSpeed, minFallingSpeed);
            physicsVector = new Vector2(0f, newphysicsVectorY);
        }

        playerTransform.SetPhycisVector(physicsVector);
    }

    public void SetPhycisVector(Vector2 v)
    {
        physicsVector = v;
    }
}
