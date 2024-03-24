using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextSc : MonoBehaviour
{

    public Text score_text;

    void ScoreTextUpdate(int v){
        score_text.text="score:"+v.ToString();
    }

}
