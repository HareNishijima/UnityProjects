using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    public GameObject enemyBulletObject;

    public void Shot()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        float angleZ = GetAngleToTarget(transform, playerObject.transform.position);
        Instantiate(enemyBulletObject, transform.position, Quaternion.Euler(0f, 0f, angleZ));
    }

    public void Machinegun()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        float angleZ = GetAngleToTarget(transform, playerObject.transform.position);
        StartCoroutine(MachinegunCoroutine(angleZ));
    }

    IEnumerator MachinegunCoroutine(float angleZ)
    {
        Instantiate(enemyBulletObject, transform.position, Quaternion.Euler(0f, 0f, angleZ));
        yield return new WaitForSeconds(0.1f);
        Instantiate(enemyBulletObject, transform.position, Quaternion.Euler(0f, 0f, angleZ));
        yield return new WaitForSeconds(0.1f);
        Instantiate(enemyBulletObject, transform.position, Quaternion.Euler(0f, 0f, angleZ));
        yield break;
    }

    float GetAngleToTarget(Transform selfTransform, Vector2 targetPosition)
    {
        Vector2 diffPosition = targetPosition - (Vector2)selfTransform.position;
        float angleToTarget = Mathf.Atan2(diffPosition.y, diffPosition.x) * Mathf.Rad2Deg;
        return angleToTarget;
    }
}
