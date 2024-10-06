using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // 通常状態から攻撃キーで攻撃状態に
        // 攻撃状態で攻撃キーを押し続けると攻撃は継続する
        // 攻撃状態では移動に関する操作は一切不可

        // 攻撃状態から攻撃キーを離すと攻撃戻り状態に
        // 攻撃戻り状態でも操作は一切不可

        // 攻撃戻り状態が終了したら通常状態へ
    }
}
