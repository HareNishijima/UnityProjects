using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    bool active;
    // time[s]
    float time;
    // mm:ss:msms
    TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        active = false;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) time += Time.deltaTime;

        timerText.text = formatTimer(time);
    }

    String formatTimer(float time)
    {
        // 分:秒:ミリ秒の形式にする（2桁0埋め）
        int m = Mathf.FloorToInt(time / 60f);
        int s = Mathf.FloorToInt(time % 60f);
        int ms = Mathf.FloorToInt(time * 100f % 100f);

        return $"{m:00}:{s:00}:{ms:00}";
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
