using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hp = 1;
    public GameObject particleObject;

    public void Damage(int damage)
    {
        hp = hp - damage;
        Instantiate(particleObject, transform.position, Quaternion.identity);
        if (hp <= 0)
        {
            Destroy(gameObject);
            new SceneManager().ToGameOver();
        }
    }

}
