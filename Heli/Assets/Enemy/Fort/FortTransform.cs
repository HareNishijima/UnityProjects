using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortTransform : MonoBehaviour
{

    GameObject playerObject;
    GameObject fortCanonObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        fortCanonObject = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // プレイヤーの方向を砲台が向く
        if (playerObject)
        {
            float angleZ = GetAngleToTarget(fortCanonObject.transform, playerObject.transform.position);
            fortCanonObject.transform.rotation = Quaternion.Euler(0f, 0f, angleZ);
        }
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
