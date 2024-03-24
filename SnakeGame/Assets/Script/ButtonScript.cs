using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    bool t;
    private Image img;

    void Start()
    {
        t = true;
        img = this.gameObject.GetComponent<Image>();
    }

    public void ButtonPush()
    {
        //ボタンが押されるたびに色が変化する
        t = !t;
        if (t)
        {
            img.color = Color.white;
        }
        else
        {
            img.color = Color.grey;
        }

    }
}
