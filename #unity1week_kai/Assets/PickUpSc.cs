using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSc : MonoBehaviour
{

    public Camera main_camera;
    GameObject pickup_obj;
    Rigidbody pickup_rb;
    bool pickup;
    LayerMask select_layermask;
    LayerMask pickup_layermask;

    // Start is called before the first frame update
    void Start()
    {
        pickup=false;
        select_layermask=~(1<<8);
        pickup_layermask=~(1<<9);
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押すと掴みモードに入る
        if(Input.GetButtonDown("Fire1") && !pickup){
            //メインカメラからrayを発射
            RaycastHit hit;
            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,select_layermask)) {
                //オブジェクトを持ち上げる
                pickup_obj=hit.transform.gameObject;
                if(pickup_obj.tag!="Kai") return;
                if(pickup_obj.GetComponent<KaiSc>().ok) return;
                pickup_rb=pickup_obj.GetComponent<Rigidbody>();
                //pickup_rb.velocity = (pickup_obj.transform.up) * 2f;
                pickup_rb.useGravity=false;
                //pickup_rb.isKinematic=true;
                pickup=true;            
            }
        //ボタンを離すとオブジェクトを落とす           
        }else if(Input.GetButtonUp("Fire1") && pickup){
            pickup_rb.useGravity=true;
            pickup_obj=null;
            pickup_rb=null;
            pickup=false; 
        }
        //右クリックかスペースキーでオブジェクトを回転させる
        else if(pickup && (Input.GetButton("Fire2")||Input.GetButton("Jump"))){
            pickup_obj.transform.Rotate(0f,0.5f,0f);
        }

        
        if(!pickup) return;	
        /*クリックしたオブジェクトを浮かす
        マウスのある場所に向かってオブジェクトが移動する
        移動はオブジェクトの速度を変更して行う*/
        RaycastHit pickup_hit;
        Ray pickup_ray = main_camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(pickup_ray, out pickup_hit,100f,pickup_layermask);
        Vector3 mouse_pos=new Vector3(pickup_hit.point.x,1f,pickup_hit.point.z);      
        Vector3 target_vec=mouse_pos-pickup_obj.transform.position;
        pickup_rb.AddForce(target_vec);
        pickup_rb.velocity*=0.98f;

    }


}
