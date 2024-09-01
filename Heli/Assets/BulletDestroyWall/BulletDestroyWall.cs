using UnityEngine;

public class BulletDestroyWall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
