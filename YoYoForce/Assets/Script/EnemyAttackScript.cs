using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public int attack_type;
    public float attack_frequency;
    public float attack_range;
    public float attack_probability;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ゲームオーバー後は攻撃しない
        if (EnemyData.player_dead) return;

        //攻撃頻度の確認
        timer += Time.deltaTime;
        AttackFrequencyCheck();
    }

    void AttackFrequencyCheck()
    {
        //攻撃頻度の確認
        if (attack_frequency < timer)
        {
            AttackRangeCheck();
            timer = 0f;
        }
    }

    void AttackRangeCheck()
    {
        //攻撃範囲の確認
        /*
        if (Mathf.Abs(this.transform.position.x - Data.player.transform.position.x) < attack_range)
        {
            AttackProbabilityCheck();
        }
        */
    }

    void AttackProbabilityCheck()
    {
        //攻撃頻度の確認
        if ( Random.Range(1f, 99f) < attack_probability)
        {
            Attack();
        }

    }

    void Attack()
    {
        //攻撃
        /*
        switch(attack_type){
            case 0:
                //ボム
                Instantiate(ObjectData.bomb, this.transform.position, Quaternion.identity);
                break;
            case 1:
                //ガン
                GameObject obj=Instantiate(ObjectData.gun, this.transform.position,this.transform.rotation);
                obj.GetComponent<GunScript>().Init(GetComponent<EnemyMoveScript>().angle);
                break;
            case 2:
                //ミサイル
                Instantiate(ObjectData.missile, this.transform.position, this.transform.rotation);
                break;
            default:
                //何もしない
                
                break;
        }
        */
        GetComponent<EnemyMoveScript>().attack = true;

    }
}
