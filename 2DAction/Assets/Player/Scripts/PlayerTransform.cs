using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Vector2 moveVector;
    Vector2 jumpVector;
    Vector2 physicsVector;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
        jumpVector = Vector2.zero;
        physicsVector = Vector2.zero;
    }

    public void MovePosition()
    {
        Vector2 newMoveVector = moveVector * Time.fixedDeltaTime;
        Vector2 newJumpVector = jumpVector * Time.fixedDeltaTime;
        Vector2 newPhysicsVector = physicsVector * Time.fixedDeltaTime;

        Vector2 newPosition = rigidbody2D.position + newMoveVector + newJumpVector + newPhysicsVector;

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

    public void SetPhycisVector(Vector2 v)
    {
        physicsVector = v;
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
        physicsVector = Vector2.zero;
    }
}
