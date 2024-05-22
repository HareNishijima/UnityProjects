using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EnemyGuide : MonoBehaviour
{
    enum State { FirstForward, Back, LastForward }
    State state;
    Rigidbody2D rb;
    float backVerticalDirection;
    Vector2 moveVec;
    Vector2[] pastPosList;

    public float speed;
    public GameObject[] enemyList;
    public int enemySpaceSize;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.FirstForward;
        moveVec = Vector2.zero;
        pastPosList = new Vector2[enemyList.Length * enemySpaceSize];
        pastPosList = Enumerable.Repeat(rb.position, pastPosList.Length).ToArray();
    }

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

        int idx = 0;
        foreach (GameObject enemy in enemyList)
        {
            enemy.transform.position = pastPosList[idx * (enemySpaceSize - 1)];
            idx++;
        }

        rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
        ShiftPastPosList();
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

    void ShiftPastPosList()
    {
        // 配列の要素を1つ右シフト
        Array.Copy(pastPosList, 0, pastPosList, 1, pastPosList.Length - 1);
        // 配列の先頭に現在の座標を設定
        pastPosList[0] = rb.position;
    }
}