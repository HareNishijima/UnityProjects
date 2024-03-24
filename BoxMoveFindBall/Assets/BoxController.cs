using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    Rigidbody rb;
    public bool Select = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  

        if(this.transform.position.y>=0.8f){           
           this.transform.Translate(0.0f,-0.1f, 0.0f);
        }

        if(this.transform.localEulerAngles.y!= 0  ){
            
        }

        if (Input.GetKey("mouse 0")){
            rb.useGravity = true;
            rb.AddForce(new Vector3(Random.Range(-6f, 6f), 1.0f, Random.Range(-6f, 6f)),
                ForceMode.Impulse);            
        }

    }
}
