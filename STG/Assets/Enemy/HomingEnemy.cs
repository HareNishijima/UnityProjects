using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxHomingAngle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = GetAngle(rb.position, Player.Instance.GetPlayerPos());
        angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angle, maxHomingAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Vector2 moveVec = new Vector2(transform.up.x, transform.up.y);
        rb.MovePosition(rb.position + moveVec * speed * Time.deltaTime);
    }

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 diff = target - start;
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
    }
}
