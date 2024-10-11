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

    void Start()
    {
        length = 0f;
    }

    public void AttackStart()
    {
        // 攻撃キーを押下開始

        // マウスの座標を取得
        Vector2 mosuePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 攻撃判定を持つオブジェクトの当たり判定を有効化
        weaponObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void AttackPlay()
    {
        // 攻撃キー押下中

        // この関数が呼び出されるたびにオブジェクトの長さを伸ばす
        length += deltaLength;
        weaponObject.transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
    }

    public void AttackEnd()
    {
        // 攻撃キーを離す

        // オブジェクトの長さを縮める
        length -= deltaReverseLength;

        // オブジェクトの長さが0以下になったら当たり判定を無効化
        if (length <= 0f)
        {
            length = 0f;
            weaponObject.transform.localScale = new Vector3(transform.localScale.x, 0f, transform.localScale.z);
            weaponObject.GetComponent<BoxCollider2D>().enabled = false;
            // todo: ステート変更
        }

        weaponObject.transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
    }
}
