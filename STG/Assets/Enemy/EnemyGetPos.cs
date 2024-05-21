using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EnemyGetPos : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2[] pastPosList;

    public int pastPosListSize;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pastPosList = new Vector2[pastPosListSize];
        pastPosList = Enumerable.Repeat(rb.position, pastPosListSize).ToArray();
    }

    public void ShiftPastPosList()
    {
        // 配列の要素を1つ右シフト
        Array.Copy(pastPosList, 0, pastPosList, 1, pastPosListSize - 1);
        // 配列の先頭に現在の座標を設定
        pastPosList[0] = rb.position;
    }

    public Vector2 GetPastPos()
    {
        return pastPosList[pastPosListSize - 1];
    }
}
