using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorSc : MonoBehaviour
{

	public GameObject cloudObj;
	float span;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Coroutine());
		span = 0f;
	}

	IEnumerator Coroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(span);
			if (GameDirectorSc.Instance.score < 10) continue;
			// 雲の生成
			Instantiate(cloudObj, new Vector2(12f, Random.Range(1f, 3f)), Quaternion.identity);
			span = Random.Range(5f, 10f);
		}
	}
}
