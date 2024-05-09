using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rb;
    bool isBack;
    float backVerticalDirection;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isBack = false;
    }

    /// <summary>
    /// 前進
    /// 画面2/3まで移動したら斜め後ろ(45°)に移動
    /// 横軸がプレイヤーと一致したら再び前進
    /// </summary>
    void Update()
    {

        if (!isBack && rb.position.x < -5f)
        {
            isBack = true;
            Vector2 playerPos = Player.Instance.GetPlayerPos();
            backVerticalDirection = Mathf.Sign(playerPos.y - rb.position.y);
        }

        Vector2 moveVec = Vector2.zero;
        if (isBack)
        {
            moveVec = new Vector2(speed, speed * backVerticalDirection);
        }
        else
        {
            moveVec = new Vector2(-speed, 0f);
        }

        rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
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
