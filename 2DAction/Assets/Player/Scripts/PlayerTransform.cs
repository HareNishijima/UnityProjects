using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Vector2 moveVector;
    Vector2 physicsVector;
    Vector2 playerVector;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
        physicsVector = Vector2.zero;
        playerVector = Vector2.zero;
    }

    public void MovePosition()
    {
        playerVector = (moveVector + physicsVector) * Time.fixedDeltaTime;
        Vector2 newPosition = rigidbody2D.position + playerVector;

        rigidbody2D.MovePosition(newPosition);
    }

    public void Move(Vector2 v)
    {
        moveVector = new Vector2(v.x, 0f);
    }

    public void SetPhycisVector(Vector2 v)
    {
        physicsVector = v;
    }

    public Vector2 GetPlayerVector()
    {
        return playerVector;
    }

    public void InitVector()
    {
        moveVector = Vector2.zero;
        physicsVector = Vector2.zero;
    }
}
