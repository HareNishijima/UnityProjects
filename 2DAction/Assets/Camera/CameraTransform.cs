using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public float cameraAreaLimit = 3f;

    public void cameraMove(Vector2 playerPosition)
    {
        // プレイヤーがカメラからどのくらい離れているかを計算
        Vector2 cameraPosition = transform.position;
        float distance = Mathf.Abs(playerPosition.x - cameraPosition.x);

        // 一定の距離離れていたら追従する
        if (distance <= cameraAreaLimit) return;
        float diff = distance - cameraAreaLimit;
        transform.position += new Vector3(diff * Mathf.Sign(playerPosition.x - cameraPosition.x), 0f, 0f);
    }
}
