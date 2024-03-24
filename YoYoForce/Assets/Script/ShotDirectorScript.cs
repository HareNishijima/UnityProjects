using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDirectorScript : MonoBehaviour
{

    public GameObject[] yoyo=new GameObject[4];
    private YoYoScript[] yoyo_sc=new YoYoScript[4];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<4;i++){
            yoyo_sc[i] = yoyo[i].GetComponent<YoYoScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*Z,X,C,Vのキーボードを押すとそれに対応したヨーヨーがマウスのある場所に向かって飛び出す
         * 速度は目的地点の少し手前まで一定　速度が0になる=目的地点につくと　発射地点に戻る
         * ヨーヨーは敵を一撃で倒し　なおかつ貫通する　連続して敵を倒すとボーナス
         * 遠い場所に向かってヨーヨーを発射すると操作不可の時間も長くなる
         */

        //汚い
        if(Input.GetKeyDown(KeyCode.Z)){
            yoyo_sc[0].Shot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            yoyo_sc[1].Shot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            yoyo_sc[2].Shot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            yoyo_sc[3].Shot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
