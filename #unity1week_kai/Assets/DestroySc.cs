using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySc : MonoBehaviour
{
    
    public BeltConveyorGeneratorSc script;

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="BeltConveyor"){
            Transform col_tra=col.gameObject.transform;
            float vec=col.gameObject.GetComponent<BeltConveyorSc>().CallVec();
            Vector3 pos=col_tra.position+new Vector3(35f,0f,0f)*-vec;      
            Transform parent_tra=col_tra.parent.gameObject.transform;
            script.CallGenerate(pos,parent_tra,vec);
        }
        Destroy(col.gameObject);
    }
}
