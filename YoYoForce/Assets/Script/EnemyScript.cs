using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private float speed;
    private Vector3 move;
    public GameObject particle;
    private GameObject set_particle;

    void Start(){
        speed = Data.insta_speed;
        move = transform.right * speed * Time.deltaTime;
        set_particle=Instantiate(particle,this.gameObject.transform);
        set_particle.transform.localRotation = Quaternion.Euler(0f,-90f,0f);
    }

    void Update(){
        //常に前進
        transform.position += move;
        Data.OverScreenDestroy(this.gameObject, Data.enemy_limit_screen_x,Data.enemy_limit_screen_y);
    }


}
