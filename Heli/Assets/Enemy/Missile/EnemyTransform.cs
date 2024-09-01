using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    float moveSpeed;
    GameObject playerObject;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // プレイヤーに向かって直進
        if (playerObject)
        {
            float angleZ = GetAngleToTarget(transform, playerObject.transform.position);
            transform.rotation = Quaternion.Euler(0f, 0f, angleZ);
        }

        Vector2 moveVec = transform.right * moveSpeed;
        rigidbody2d.position += moveVec * Time.fixedDeltaTime;
    }

    float GetAngleToTarget(Transform selfTransform, Vector2 targetPosition)
    {
        float deltaAngle = 1f;

        Vector2 diffPosition = targetPosition - (Vector2)selfTransform.position;
        float angleToTarget = Mathf.Atan2(diffPosition.y, diffPosition.x) * Mathf.Rad2Deg;
        float adjustedAngleToTarget = Mathf.MoveTowardsAngle(selfTransform.eulerAngles.z, angleToTarget, deltaAngle);

        return adjustedAngleToTarget;
    }
}
