using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerAttack : MonoBehaviour
{

    float length;
    public float deltaLength;
    public float deltaReverseLength;

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
    }

    public void AttackPlay(){
        // 攻撃キー押下中

        // この関数が呼び出されるたびにオブジェクトの長さを伸ばす
        // length += deltaLength;
    }

    public void AttackEnd(){
        // 攻撃キーを離す

        // オブジェクトの長さを縮める
        // length -= deltaReverseLength;

        // オブジェクトの長さが0以下になったら当たり判定を無効化
    }
}
