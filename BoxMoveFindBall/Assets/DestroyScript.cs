using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    void Start(){
        Invoke("Des", 0.1f);
    }
    
    void OnTriggerEnter(Collider col){
        Destroy(col.gameObject);
    }
   
    void Des(){
        Destroy(this.gameObject);
    }

}
