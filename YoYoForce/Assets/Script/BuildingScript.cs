using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public GameObject yoyo;

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Enemy"){

            //敵に接触するとビルとヨーヨーが破壊される
            Data.building_list.Remove(this.gameObject);
            Instantiate(Data.building_dead_particle, transform.position, Quaternion.identity);
            AudioDirectorScript.Play(Data.building_dead_se);
            Instantiate(Data.yoyo_dead_particle, yoyo.transform.position, Quaternion.Euler(90f, 0f, 0f));


            //全部破壊されたらゲームオーバー
            if (Data.building_list.Count==0){
                GameDirectorScript.CallGameOver();
            }

            //ビルが破壊されるごとに敵がよりビルの根本を狙うようになる
            //同じ場所を狙い続けなくなるのでより倒すのが難しくなる
            Data.building_aim_point += 1.5f;


            Destroy(yoyo);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
