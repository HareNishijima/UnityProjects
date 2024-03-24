using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{

    private float timer;
    private int pos;

    public GameObject enemy;
    private Vector3 insta_pos;
    private Vector3 aim_pos;

    private int select;
    private GameObject select_object;
    private float look_angle;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        select = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (Data.insta_span < timer)
        {
            EnemyGenerate(enemy);
            timer = 0f;
        }
    }

    void EnemyGenerate(GameObject enemy) {
        //敵の出現位置はY座標は固定だがX座標はランダムに決まり生存しているビルの内一つを狙う

        //全滅したなら実行しない
        if (Data.building_list.Count == 0) return;

        for(int i=0; i < Data.insta_simultaneous; i++){
            select = Random.Range( 0 , Data.building_list.Count );
            select_object = Data.building_list[select];
            insta_pos = new Vector3(Random.Range(-8f, 8f), 5.5f, 0f);
            aim_pos = new Vector3(0f, Random.Range(0f, Data.building_aim_point));
            look_angle = Data.GetAngle(insta_pos, select_object.transform.position + aim_pos);
            Instantiate(enemy, insta_pos, Quaternion.Euler(0f, 0f, look_angle));
        }
    }
}