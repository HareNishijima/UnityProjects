using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    Vector2 moveVector;
    Vector2 jumpVector;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(moveVector.x, jumpVector.y));

        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
    }

    public void Move(Vector2 v)
    {
        moveVector = new Vector2(v.x, 0f) * Time.fixedDeltaTime;
    }

    public void SetJumpVector(Vector2 v)
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
