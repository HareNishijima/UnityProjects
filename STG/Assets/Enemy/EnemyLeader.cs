using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EnemyLeader : MonoBehaviour
{
    enum State { FirstForward, Back, LastForward }
    State state;
    Rigidbody2D rb;
    float backVerticalDirection;
    Vector2 moveVec;
    Vector2[] pastPosList;

    public float speed;
    public int pastPosListSize;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.FirstForward;
        moveVec = Vector2.zero;
        pastPosList = new Vector2[pastPosListSize];
        pastPosList = Enumerable.Repeat(rb.position, pastPosListSize).ToArray();
    }

    /// <summary>
    /// 前進
    /// 画面2/3まで移動したら斜め後ろ(45°)に移動
    /// 横軸がプレイヤーと一致したら再び前進
    /// </summary>
    void FixedUpdate()
    {

        switch (state)
        {
            case State.FirstForward:
                FirstForward();
                break;
            case State.Back:
                Back();
                break;
            case State.LastForward:
                LastForward();
                break;
        }

        // 配列の要素を1つ右シフト
        Array.Copy(pastPosList, 0, pastPosList, 1, pastPosListSize - 1);
        // 配列の先頭に現在の座標を設定
        pastPosList[0] = rb.position;

        rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
    }

    void FirstForward()
    {
        if (rb.position.x < -5f)
        {
            Vector2 playerPos = Player.Instance.GetPlayerPos();
            backVerticalDirection = Mathf.Sign(playerPos.y - rb.position.y);
            state = State.Back;
            moveVec = Vector2.zero;
            return;
        }
        moveVec = new Vector2(-speed, 0f);
    }

    void Back()
    {
        Vector2 playerPos = Player.Instance.GetPlayerPos();
        bool check = false;
        if (backVerticalDirection < 0f)
        {
            check = (rb.position.y <= playerPos.y);
        }
        else
        {
            check = (rb.position.y >= playerPos.y);
        }

        if (check)
        {
            rb.MovePosition(new Vector2(rb.position.x, playerPos.y));
            state = State.LastForward;
            moveVec = Vector2.zero;
            return;
        }
        moveVec = new Vector2(speed, speed * backVerticalDirection);
    }

    void LastForward()
    {
        moveVec = new Vector2(-speed, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    public Vector2 GetPastPos()
    {
        return pastPosList[pastPosListSize - 1];
    }
}
