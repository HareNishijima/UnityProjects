using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class PlayerAttack : MonoBehaviour
{

    float length;
    public float deltaLength;
    public float deltaReverseLength;
    public GameObject weaponObject;
    PlayerState playerState;

    void Start()
    {
        length = 0f;
        playerState = GetComponent<PlayerState>();
    }

    public void AttackStart(Vector2 AxisRawInput)
    {
        playerState.ToAttack();

        Vector2 targetPosition = (Vector2)transform.position + AxisRawInput;
        float angle = GetAngleToTarget(weaponObject.transform, targetPosition);

        weaponObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        weaponObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void AttackPlay()
    {
        length += deltaLength * Time.fixedDeltaTime;
        weaponObject.transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
    }

    public void AttackEnd()
    {
        length -= deltaReverseLength * Time.fixedDeltaTime;

        if (length > 0f)
        {
            weaponObject.transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
            return;
        }

        // 武器のlengthが0になったら終了
        length = 0f;
        weaponObject.transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
        weaponObject.GetComponent<BoxCollider2D>().enabled = false;
        playerState.ToReady();
        return;
    }

    float GetAngleToTarget(Transform selfTransform, Vector2 targetPosition)
    {
        Vector2 diffPosition = targetPosition - (Vector2)selfTransform.position;
        float angleToTarget = Mathf.Atan2(diffPosition.y, diffPosition.x) * Mathf.Rad2Deg;
        return angleToTarget;
    }
}
