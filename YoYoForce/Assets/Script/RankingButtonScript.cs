using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingButtonScript : MonoBehaviour
{


    //ランキングボタン
    public void RankingButton()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Data.score);
    }

}
