using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hp = 1;

    public void Damage(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
