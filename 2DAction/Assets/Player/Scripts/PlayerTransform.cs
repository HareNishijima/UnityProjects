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

    public void MovePosition()
    {
        Vector2 newPosition = rigidbody2D.position + new Vector2(moveVector.x, jumpVector.y) * Time.fixedDeltaTime;
        newPosition = new Vector2(Mathf.Max(-7f, Mathf.Min(newPosition.x, 7f)), newPosition.y);
        rigidbody2D.MovePosition(newPosition);
    }

    public void Move(Vector2 v)
    {
        moveVector = new Vector2(v.x, 0f);
    }

    public void Jump(Vector2 v)
    {
        jumpVector = v;
    }

    public Vector2 GetMoveVector()
    {
        return moveVector;
    }

    public Vector2 GetJumpVector()
    {
        return jumpVector;
    }

    public void InitVector()
    {
        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
    }
}
