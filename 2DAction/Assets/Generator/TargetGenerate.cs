using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerate : MonoBehaviour
{

    public GameObject targetObject;
    public float generateSpan = 2f;
    public float deltaGenerateSpan = 0.1f;
    public float minGenerateSpan = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    void Generate()
    {
        Vector2 generatePos = new Vector2(Random.Range(-16f, 16f), Random.Range(4f, 16f));
        Instantiate(targetObject, generatePos, Quaternion.identity);
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(generateSpan);
            generateSpan = Mathf.Clamp(generateSpan - deltaGenerateSpan, minGenerateSpan, generateSpan);
        }
    }
}
