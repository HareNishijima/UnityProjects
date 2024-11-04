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
        rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(moveVector.x, jumpVector.y) * Time.fixedDeltaTime);
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

    public void InitVector(){
        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
    }
}
