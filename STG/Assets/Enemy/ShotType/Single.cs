using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single : MonoBehaviour
{

    public GameObject shotObj;
    public float span;

    void Start()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            Shot();
            yield return new WaitForSeconds(span);
        }
    }

    void Shot()
    {
        Instantiate(shotObj, transform.position, Quaternion.identity);
    }
}
