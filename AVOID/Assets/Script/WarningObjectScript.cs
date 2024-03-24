using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningObjectScript : MonoBehaviour
{

    private GameObject player;
    private float deg = 0;
    public float speed;
    private bool isActive = true;
    public float limit =1f;
    public GameObject danger_object;
    private Vector3 home_pos;
    private Vector3 random_pos;
    public GameObject warning_object_generator;
    private WarningObjectGenerator warning_object_generator_script;

    //当たり判定の無い警告線を飛ばし
    //一定時間後、同じ軌道を通る敵弾を飛ばす

    void Start()
    {
        //タグからプレイヤーを探して見つける
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Destroy(this.gameObject);
        }
        //タグからwarningobjectgeneratorを探して見つける
        warning_object_generator = GameObject.FindWithTag("WOG");
        if(warning_object_generator==null){
            Destroy(this.gameObject);
        }
        warning_object_generator_script = warning_object_generator.GetComponent<WarningObjectGenerator>();

        //今いる座標を記憶する(敵弾の処理に必要)
        home_pos = this.transform.position;

        
        //画面内のランダムな場所を向く
        random_pos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4.5f, 4.5f), 0);
        deg = GetAngle(this.transform.position,random_pos);
        transform.rotation = Quaternion.Euler(0, 0, deg);
        
  
    }

    //直進
    void Update()
    {
        //WarningObjectGeneratorからの引数がtrueになれば
        //dangerobjectを生成する
        if(warning_object_generator_script.danger_object_instantiate){
            InstantiateDanger();
        }

        //アクティブでなければ動かない
        if (!(isActive)) return;

        //直進
        transform.position += transform.right * speed;

        //画面外に出たらアクティブでなくなる
        if (Mathf.Abs(transform.position.x) > 30f || Mathf.Abs(transform.position.y) > 30f)
        {
            isActive = false;
        }

    }

    //自身を破壊し敵弾を生成する
    void InstantiateDanger(){
        Instantiate(danger_object,home_pos, transform.rotation);
        Destroy(this.gameObject);
    }
    
    //2点間の角度を取得
    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dif = target - start;
        float rad = Mathf.Atan2(dif.y, dif.x);
        float deg = rad * Mathf.Rad2Deg;
        return deg;
    }


}
