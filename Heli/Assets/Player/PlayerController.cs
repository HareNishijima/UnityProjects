using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform {
    public Vector2 position;
    public Quaternion quaternion;
    float speed=10f;

    public PlayerTransform(Vector2 p, Quaternion q){
        position = p;
        quaternion = q;
    }

    public PlayerTransform Controller(Vector2 input){
        Vector2 newPosition = input * speed * Time.deltaTime + position;

        float r = -input.x;
        if(r == 0f) r = input.y;
        Quaternion qua = Quaternion.Euler(0f, 0f, r * 45f);

        return new PlayerTransform(newPosition, qua);
    }
}

public class PlayerController : MonoBehaviour
{
    PlayerTransform playerTransform;
    Rigidbody2D rigidbody2d;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = new PlayerTransform(transform.position, transform.rotation);
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        playerTransform = playerTransform.Controller(input);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = playerTransform.position;
        transform.rotation = playerTransform.quaternion;
    }
}
