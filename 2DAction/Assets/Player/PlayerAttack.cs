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
    PlayerAttackState playerAttackState;

    void Start()
    {
        length = 0f;
        playerAttackState = GetComponent<PlayerAttackState>();
    }

    public void AttackStart()
    {
        // 攻撃キーを押下開始

        // マウスの座標を取得
        Vector2 mosuePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = GetAngleToTarget(weaponObject.transform, mosuePosition);
        weaponObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // 攻撃判定を持つオブジェクトの当たり判定を有効化
        weaponObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void AttackPlay()
    {
        // 攻撃キー押下中

        // この関数が呼び出されるたびにオブジェクトの長さを伸ばす
        length += deltaLength * Time.fixedDeltaTime;
        weaponObject.transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
    }

    public void AttackEnd()
    {
        // 攻撃キーを離す

        // オブジェクトの長さを縮める
        length -= deltaReverseLength * Time.fixedDeltaTime;

        // オブジェクトの長さが0以下になったら当たり判定を無効化
        if (length <= 0f)
        {
            length = 0f;
            weaponObject.transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
            weaponObject.GetComponent<BoxCollider2D>().enabled = false;
            playerAttackState.ToReady();
        }

        weaponObject.transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
    }

    float GetAngleToTarget(Transform selfTransform, Vector2 targetPosition)
    {
        Vector2 diffPosition = targetPosition - (Vector2)selfTransform.position;
        float angleToTarget = Mathf.Atan2(diffPosition.y, diffPosition.x) * Mathf.Rad2Deg;

        return angleToTarget;
    }
}
