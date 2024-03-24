using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObjectScript : MonoBehaviour
{
    //ひたすら直進する
    //既にWarningObjectで色々設定済み

    public float speed;

    // Update is called once per frame
    void Update()
    {
        //直進
        transform.position += transform.right * speed;

        //画面外に出たら自身を破壊
        if (Mathf.Abs(transform.position.x) > 30f || Mathf.Abs(transform.position.y) > 30f)
        {
            Destroy(this.gameObject);
        }
    }
}
