using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirectorSc : MonoBehaviour
{
    public Camera cam;
    public Text time_text;
    public Text title_text;
    public Image result_screen;
    public Image how_to_screen;
    public Text result_text;

    public void TitleText(string s){
        title_text.text=s;
    }

    public void HowToScreenBool(bool b){
        how_to_screen.gameObject.SetActive(b);
    }

    public void ResultScreenBool(bool b){
        result_screen.gameObject.SetActive(b);
    }

    public void TitleTextBool(bool b){
        title_text.gameObject.SetActive(b);
    }
    public void TimeTextUpdate(int v){
        time_text.text="time:"+v.ToString();
    }
    public void ResultText(bool b,int v){
        result_text.gameObject.SetActive(b);
        result_text.text="￥ "+v.ToString();
    }

}
