using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hp = 1;
    public GameObject particleObject;

    public void Damage(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Instantiate(particleObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
