using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { FirstForward, Back, LastForward }
    State state;
    Rigidbody2D rb;
    bool isBack;
    float backVerticalDirection;
    Vector2 moveVec;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isBack = false;
        state = State.FirstForward;
        moveVec = Vector2.zero;
    }

    /// <summary>
    /// 前進
    /// 画面2/3まで移動したら斜め後ろ(45°)に移動
    /// 横軸がプレイヤーと一致したら再び前進
    /// </summary>
    void Update()
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

        rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
    }

    void FirstForward()
    {
        if (!isBack && rb.position.x < -5f)
        {
            state = State.Back;
            Vector2 playerPos = Player.Instance.GetPlayerPos();
            backVerticalDirection = Mathf.Sign(playerPos.y - rb.position.y);
        }

        moveVec = new Vector2(-speed, 0f);
    }

    void Back()
    {
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
}
