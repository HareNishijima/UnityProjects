using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningObjectGenerator : MonoBehaviour
{

    public GameObject warning_object;
    private float time = 0f;
    public float span;
    public int generate_num;
    public int generate_count;
    public float interval;

    public PlayerScript player;
    public string mode = "normal";
    public bool danger_object_instantiate = false;

    void Start(){      
        time = span / 2f;
    }

    /* 一定時間ごとにオブジェクトを生成する
     * レベルが増加すると一度に生成するオブジェクトの数が増加する
     * 更にレベルが上昇するとオブジェクトが時間差で生成される
     */
    void Update()
    {
        //プレイヤーが破壊されたらこのオブジェクトはアクティブでなくなる
        if (player.isDead) this.gameObject.SetActive(false);    

        time += Time.deltaTime;
        //通常状態からspan秒経ったら生成状態にする
        if (mode == "normal" && time > span){
            mode = "generate";
            time = 0;
            danger_object_instantiate = false;
        }
        //生成状態からinterval秒ごとにwarningobjectを生成する
        else if(mode== "generate" && time > interval){
            Generate(generate_num);
            time = 0;
            generate_count++;
            //生成状態からgenerate_count個warningobjectを生成し、通常状態に戻る
            //一度に生成されるオブジェクトの数が１つずつ増える
            if(generate_count>=generate_num){
                mode = "normal";
                generate_count = 0;
                generate_num++;
                //それから一定時間経過したらdanger_object_instantiateをtrueにし
                //dangerobjectを生成する
                Invoke("SetDangerObjectInstantiate",1f);
                
            }
        }

    }

    void SetDangerObjectInstantiate(){
        danger_object_instantiate = true;
    }



    private int select;
    private Vector3 generate_pos;

    //warningobjectの生成
    void Generate(int num){
        //出現位置をランダムに決める
        select = Random.Range(0, 2);
        switch (select)
        {
            case 0:
                generate_pos = new Vector3(Random.Range(-3.5f, 3.5f), 5.5f * (1 - Random.Range(0, 2) * 2), 0);
                break;
            case 1:
                generate_pos = new Vector3(3.5f * (1 - Random.Range(0, 2) * 2), Random.Range(-5.5f, 5.5f), 0);
                break;
        }
        //生成
        Instantiate(warning_object, generate_pos, Quaternion.identity);
    }
}
