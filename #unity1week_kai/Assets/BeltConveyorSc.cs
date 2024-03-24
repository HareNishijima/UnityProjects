using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyorSc : MonoBehaviour
{

    Rigidbody rb;
    float speed;
    Vector3 move;
    float vec;
    GameDirectorSc game_dir_sc;

    void Start(){
        rb=GetComponent<Rigidbody>();
        game_dir_sc=GameObject.FindWithTag("GameDirector").GetComponent<GameDirectorSc>();
    }

    public void Initial(float s){
        vec=Mathf.Sign(s);
    }

    public float CallVec(){
        return vec;
    }


    void Update(){
        move=new Vector3(game_dir_sc.speed*vec,0f,0f);
        rb.MovePosition(transform.position+move);
    }

}
