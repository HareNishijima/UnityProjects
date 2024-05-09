using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Singleton<Controller>
{
    Rigidbody2D rb;

    public float speed;
    public GameObject shotObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVec = moveInput * speed;

        bool shotInput = Input.GetButtonDown("Fire1");
        if (shotInput)
        {
            Shot();
        }

        rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
    }

    void Shot()
    {
        Instantiate(shotObj, rb.position + new Vector2(0.5f, 0f), Quaternion.identity);
    }

}
