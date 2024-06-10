using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D rb;

    public float startSpeed;
    public float descFirstSpeed;
    public float descLastSpeed;
    public float limitSpeed;


    Vector2 vec;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vec = new Vector2(startSpeed, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (vec.x > 0f)
        {
            vec = new Vector2(Mathf.Max(vec.x - descFirstSpeed, -limitSpeed), 0f);
        }
        else
        {
            vec = new Vector2(Mathf.Max(vec.x - descLastSpeed, -limitSpeed), 0f);
        }

        rb.MovePosition(rb.position + vec * Time.deltaTime);
    }
}
