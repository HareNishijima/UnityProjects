using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyorGeneratorSc : MonoBehaviour
{

    public GameObject belt_conveyor_obj;
    Transform front_belt_conveyor_tra;
    Transform rear_belt_conveyor_tra;

    // Start is called before the first frame update
    void Start()
    {
        front_belt_conveyor_tra = new GameObject("FrontBeltConveyor").transform;
        rear_belt_conveyor_tra = new GameObject("RearBeltConveyor").transform;
        for(float i=-3f;i<=3f;i+=1f){
            CallGenerate(new Vector3(-5f*i,-0.5f,0f),front_belt_conveyor_tra,1f);
            CallGenerate(new Vector3(5f*i,-0.5f,6.1f),rear_belt_conveyor_tra,-1f);
        }        
    }

    public void CallGenerate(Vector3 pos,Transform parent_tra,float vec){
            GameObject insta_obj=Instantiate(belt_conveyor_obj,pos,Quaternion.identity,parent_tra);
            insta_obj.GetComponent<BeltConveyorSc>().Initial(vec);
    }


}
