using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    enum State { FirstForward, Back, LastForward }
    State state;
    Rigidbody2D rb;
    float backVerticalDirection;
    Vector2 moveVec;
    float speed;

    public EnemyLeader enemyLeader;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.FirstForward;
        moveVec = Vector2.zero;
        speed = enemyLeader.GetSpeed();
    }

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
        if (rb.position.x < enemyLeader.GetBackStartPos().x)
        {
            rb.MovePosition(enemyLeader.GetBackStartPos());
            backVerticalDirection = enemyLeader.GetBackVerticalDirection();
            state = State.Back;
            return;
        }

        moveVec = new Vector2(-speed, 0f);
    }

    void Back()
    {
        if (rb.position.x > enemyLeader.GetLastForwardStartPos().x)
        {
            rb.MovePosition(enemyLeader.GetLastForwardStartPos());
            state = State.LastForward;
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
}
