using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public float cameraAreaLimit = 3f;
    GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        Vector2 cameraPosition = transform.position;
        Vector2 playerPosition = playerObject.transform.position;

        // プレイヤーがカメラからどのくらい離れているかを計算
        float distance = Mathf.Abs(playerPosition.y - cameraPosition.y);

        // 一定の距離離れていたら追従する
        if (distance > cameraAreaLimit)
        {
            float diff = distance - cameraAreaLimit;
            transform.position += new Vector3(0f, diff * Mathf.Sign(playerPosition.y - cameraPosition.y), 0f);
        }
    }
}
