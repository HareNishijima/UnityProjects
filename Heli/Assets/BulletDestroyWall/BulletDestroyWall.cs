using UnityEngine;

public class BulletDestroyWall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
        }

    }
}
