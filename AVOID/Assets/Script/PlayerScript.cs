using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed = 1f;
    public int level = 1;
    public GameObject explosion;
    private Vector3 player_pos;
    private Vector3 start_pos;
    private Vector3 move_pos;
    public bool isDead = false;


    // Update is called once per frame
    void Update()
    {
        //プレイヤーが死んだ場合操作できない
        if (isDead) return;     

        //タッチした座標を起点とする
        if(Input.GetMouseButtonDown(0)){
            start_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            start_pos.z = 0f;
            player_pos = transform.position;
        }
        //タッチし続けている間、起点からの相対座標
        //の数だけプレイヤーが移動する
        else if(Input.GetMouseButton(0)){
            move_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - start_pos;
            move_pos.z = 0f;
            transform.position = move_pos*speed+player_pos;

        }

    }

    //敵弾に当たると爆発のオブジェクトを生成する
    //プレイヤーの当たり判定を無くす
    //その0.25F後にプレイヤーを破壊する
    void OnCollisionEnter2D(Collision2D col){
        isDead = true;
        Instantiate(explosion,transform.position,Quaternion.identity);
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(this.gameObject,0.25f);
    }

}
