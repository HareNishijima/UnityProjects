using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHP>().Damage(1);
        }
        Destroy(gameObject);
    }
}
