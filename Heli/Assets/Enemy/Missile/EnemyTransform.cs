using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    float moveSpeed;
    GameObject playerObject;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // プレイヤーに向かって直進
        if (playerObject)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, GetAngle(transform.position, playerObject.transform.position));
        }

        Vector2 moveVec = transform.right * moveSpeed;
        rigidbody2d.position += moveVec * Time.fixedDeltaTime;
    }

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 diff = target - start;
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }
}
