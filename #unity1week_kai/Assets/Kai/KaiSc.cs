using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaiSc : MonoBehaviour
{

    public bool ok;
    Rigidbody rb;
    LayerMask layer_mask;
    public GameObject particle;

    // Start is called before the first frame update
    void Awake()
    {
        ok=false;
        rb=GetComponent<Rigidbody>();
        layer_mask=(1<<9);
    }

    void OnCollisionStay(Collision col){
        if(!ok && col.gameObject.tag=="KaiBig"){
            KaiHitCheck(col.gameObject.transform);
        }
    }

    void KaiHitCheck(Transform col_tra){

        Transform tra=transform;
        //自分の座標と親の座標が近いと基礎点数が入る 0~100
        float base_point=Mathf.InverseLerp(0f,2f,Vector3.Distance(tra.position,col_tra.position));
        //Debug.Log("distance:"+base_point.ToString());
        base_point=Mathf.Lerp(0f,100f,1f-base_point);
        
        //33点以下ならばカウントされない
        if(base_point<33f) return;    
        
        //Debug.Log("basepoint:"+base_point.ToString());
        //自分の角度が90*n度なら基礎点数に倍率がかかる 0~3
        float bonus_point=Mathf.InverseLerp(0f,90f,tra.localEulerAngles.y%90f);
        //Debug.Log("rot:"+bonus_point);
        bonus_point=Mathf.Lerp(0f,3f,1f-bonus_point);
        //Debug.Log("bonuspoint"+bonus_point);
        //コメントアウトしたプログラムはここに追加する

        int score=Mathf.RoundToInt(base_point*bonus_point);


        ok=true;
        GameObject.FindWithTag("AudioDirector").GetComponent<AudioDirectorSc>().AudioOneShot(1);
        Instantiate(particle,transform.position,Quaternion.identity);
        GameDirectorSc sc=GameObject.FindWithTag("GameDirector").GetComponent<GameDirectorSc>();
        sc.IncScore(score);

        /*
        //真下にレイを飛ばして、それぞれKaiにヒットしたらOK
        float scale=this.transform.localScale.x;
        RaycastHit ray_hit;
        Vector3 parent_pos;
        Transform child_tra;
        //NSEW
        for(int i=0;i<4;i++){
            parent_pos=transform.position;
            child_tra=transform.GetChild(i).gameObject.transform;
            ray_hit=RayCheck(child_tra.position+child_tra.up*scale/25f,child_tra.up,scale);    
            if(ray_hit.collider==null){
                ray_hit=RayCheck(child_tra.position-child_tra.up*scale/25f,-child_tra.up,scale);
                if(ray_hit.collider==null) return;
            }
            //Debug.Log(ray_hit.transform.gameObject);
            if(ray_hit.transform.gameObject.tag=="Kai"){
                //Debug.Log("hit");
                continue;
            }else{
                return;
            }

        }

        */


        //Debug.Log("OK!");

    }

    private RaycastHit RayCheck(Vector3 p,Vector3 v,float r){
        RaycastHit ray_hit;
        Ray ray = new Ray (p,v);
        Physics.Raycast (ray, out ray_hit,r,layer_mask);
        Debug.DrawRay (ray.origin, ray.direction * r, Color.red, 1f);
        return ray_hit;
    } 

}
