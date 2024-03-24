using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{

    public int move_type;
    public bool attack;

    public float speed;
    public float angle;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        attack = false;

        //自分の位置によってどちらへ向かうか決める
        if (this.transform.position.x > 0)
        {
            speed *= -1;
            angle += 180f;
        }

        angle *= -1f;

        switch (move_type)
        {
            case 0:
                //横に移動
                move = new Vector3(speed, 0f, 0f) * Time.deltaTime;
                break;
            case 1:
                //Z字に移動　一時的にmove=new Vector3(0f,speed/5f,0f)
                move = new Vector3(speed, 0f, 0f) * Time.deltaTime;
                break;
            case 2:
                //V字に移動　move.yを反転
                move = new Vector3(speed * Mathf.Cos(angle * Mathf.Deg2Rad),
                                            speed * Mathf.Sin(angle * Mathf.Deg2Rad), 0f) * Time.deltaTime;
                break;
            default:
                move = new Vector3(speed, 0f, 0f) * Time.deltaTime;
                break;
        }
    }

    void FixedUpdate(){
        //移動
        this.transform.position += move;
        //画面外に出たら破壊
        Data.OverScreenDestroy(this.gameObject, Data.enemy_limit_screen_x, Data.enemy_limit_screen_y);
    }



    public void ChangeMove1(){
        
    }

    public void ChangeMove2(){
        //move.yを反転する
        move.y *= -1;
    }


}
