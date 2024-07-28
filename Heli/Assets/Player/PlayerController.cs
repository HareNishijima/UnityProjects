using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 position;
    Quaternion quaternion;
    Rigidbody2D rigidbody2d;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(0f,0f);
        quaternion = Quaternion.identity;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        position += input * speed * Time.deltaTime;

        float rotate = transform.rotation.z;
        rotate = Input.GetAxis("Vertical") - Input.GetAxis("Horizontal");
        quaternion = Quaternion.AngleAxis(rotate * 45f, Vector3.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.position = position;
        transform.rotation = quaternion;
    }
}
