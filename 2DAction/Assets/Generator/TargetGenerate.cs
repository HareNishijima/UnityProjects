using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerate : MonoBehaviour
{

    public GameObject targetObject;
    public float generateSpan = 2f;
    public float deltaGenerateSpan = 0.1f;
    public float minGenerateSpan = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    void Generate()
    {
        Vector2 generatePos = new Vector2(Random.Range(-16f, 16f), Random.Range(4f, 16f));
        GameObject playerObject = GameObject.FindWithTag("Player");
        // プレイヤーが見つからなければvector3.zeroを指定
        Vector2 playerPos = playerObject?.transform.position ?? Vector3.zero;

        float angle = GetAngleToTarget(generatePos, playerPos);
        Instantiate(targetObject, generatePos, Quaternion.Euler(0f, 0f, angle));
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(generateSpan);
            generateSpan = Mathf.Clamp(generateSpan - deltaGenerateSpan, minGenerateSpan, generateSpan);
        }
    }

    float GetAngleToTarget(Vector2 selfPosition, Vector2 targetPosition)
    {
        Vector2 diffPosition = targetPosition - selfPosition;
        float angleToTarget = Mathf.Atan2(diffPosition.y, diffPosition.x) * Mathf.Rad2Deg;

        return angleToTarget;
    }
}
