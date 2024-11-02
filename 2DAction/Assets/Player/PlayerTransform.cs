using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    Vector2 moveVector;
    Vector2 jumpVector;
    PlayerCollisionCheck playerCollisionCheck;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
        playerCollisionCheck = GetComponent<PlayerCollisionCheck>();
    }

    void Update()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(moveVector.x, jumpVector.y));

        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;

        // 判定のチェック
        playerCollisionCheck.CheckGround();
    }

    public void Move(Vector2 v)
    {
        moveVector = new Vector2(v.x, 0f) * Time.fixedDeltaTime;
    }

    public void Jump(Vector2 v)
    {
        jumpVector = v * Time.fixedDeltaTime;
    }

    public Vector2 GetMoveVector()
    {
        return moveVector;
    }

    public Vector2 GetJumpVector()
    {
        return jumpVector;
    }
}
