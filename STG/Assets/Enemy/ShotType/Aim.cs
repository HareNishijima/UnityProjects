using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject shotObj;
    public float span;

    void Start()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Shot();
            yield return new WaitForSeconds(span);
        }
    }

    void Shot()
    {
        float angle = GetAngle(transform.position, Player.Instance.GetPlayerPos());
        Instantiate(shotObj, transform.position, Quaternion.Euler(0f, 0f, angle));
    }



    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 diff = target - start;
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 180f;
    }
}
