using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirectorScript : MonoBehaviour
{

    public Text _score;
    public static Text score;

    void Awake(){
        score = _score;
        Score(0);
    }

    //スコアの更新と表示　レベルアップと敵出現パラメータの変化
    public static void Score(int s){
        Data.score += s;
        score.text = Data.score.ToString("000");

        //敵を倒した数がレベルに相当する
        //連続して敵を倒した場合　スコアは大きく上昇するがレベルは一定なのでお得
        LevelUp(++Data.level);

    }

    public static void LevelUp(int level){

        //レベル5毎に敵の生成スパンが減少
        if(level%5==0){
            Data.insta_span -= 0.1f;
            Data.insta_span = Mathf.Clamp(Data.insta_span, 0.5f, 2f);
            //レベル10毎にスピードが1段階上昇する
            if (level % 10 == 0)
            {
                Data.insta_speed += 0.2f;
                //レベル20毎に同時に生成される敵の数が+1される
                if ((level % 20 == 0) && (Data.insta_simultaneous<5))
                {
                    Data.insta_simultaneous++;
                    Data.insta_span += 0.5f;
                    Data.insta_speed -= 0.5f;
                }
            }

        }
    }
}
