using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    public GameObject enemyBulletObject;

    public void Shot()
    {
        Instantiate(enemyBulletObject, transform.position, transform.rotation);
    }
}
