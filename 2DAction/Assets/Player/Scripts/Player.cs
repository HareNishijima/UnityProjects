using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    PlayerTransform playerTransform;
    PlayerCollisionCheck playerCollisionCheck;
    PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<PlayerTransform>();
        playerCollisionCheck = GetComponent<PlayerCollisionCheck>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform.MovePosition();

        // 判定のチェック
        playerCollisionCheck.CheckGround();

        // アニメーション遷移
        playerAnimation.Animation();

        // 移動とジャンプのベクトルをリセット
        playerTransform.InitVector();
    }
}
