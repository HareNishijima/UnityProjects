using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
