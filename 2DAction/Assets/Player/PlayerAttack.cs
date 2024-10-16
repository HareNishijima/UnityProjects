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
        //Vector2 targetPosition = (Vector2)transform.position + AxisRawInput;
        Vector2 targetPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = GetAngleToTarget(weaponObject.transform, targetPosition);

        weaponObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        weaponObject.GetComponent<BoxCollider2D>().enabled = true;

        playerState.ToAttack();
    }

    public void AttackPlay()
    {
        length += deltaLength * Time.fixedDeltaTime;
        weaponObject.transform.localPosition = weaponObject.transform.right * length;
    }

    public void AttackEnd()
    {
        length -= deltaReverseLength * Time.fixedDeltaTime;

        if (length > 0f)
        {
            weaponObject.transform.localPosition = weaponObject.transform.right * length;
            return;
        }

        // 武器のlengthが0になったら終了
        length = 0f;
        weaponObject.transform.localPosition = Vector3.zero;
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
