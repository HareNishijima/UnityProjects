using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 前進
    /// 画面1/2まで移動したら斜め後ろ(45°)に移動
    /// 横軸がプレイヤーと一致したら再び前進
    /// </summary>
    void Update()
    {

        Vector2 moveVec = new Vector2(-speed, 0f);
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
