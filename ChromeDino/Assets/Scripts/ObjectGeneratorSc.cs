using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneratorSc : MonoBehaviour
{

	public GameObject[] cactusList;
	public GameObject ptelanodon;

	float span;
	int[] cactusNum;

	// Start is called before the first frame update
	void Start()
	{
		span = 3f;
		cactusNum = new int[10] { 1, 1, 1, 2, 2, 2, 2, 3, 3, 4 };
		StartCoroutine(Coroutine());
	}

	IEnumerator Coroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(span);
			ObjectGenerate();
			span = Random.Range(2f, 4f);
		}
	}

	void ObjectGenerate()
	{
		if (GameDirectorSc.Instance.score < 10) return;

		/*
        登場するオブジェクトの種類
        ・サボテン(1, 2連, 3連, 4連)
        ・プテラノドン上段(頭上　そのまま・しゃがみで回避)
        ・プテラノドン中段(胴体　ジャンプ・しゃがみで回避)
        ・プテラノドン下段(足元　ジャンプで回避)
        */

		/*
		プテラノドンはスコアが200を超えてから
		4連サボテンはスコアが400を超えてから
		*/

		int random = Random.Range(0, 100);


		//if (random < 30 && GameDirectorSc.Instance.score >= 200)
		// デバッグ用
		if (GameDirectorSc.Instance.score >= 100)
		{
			// プテラノドン(30%)
			random = Random.Range(0, 100);
			if (random < 30f)
			{
				// 上段
				Instantiate(ptelanodon, new Vector2(12f, 1.2f), Quaternion.identity);
			}
			else if (random < 70f)
			{
				// 中段
				Instantiate(ptelanodon, new Vector2(12f, 0.5f), Quaternion.identity);
			}
			else
			{
				// 下段
				Instantiate(ptelanodon, new Vector2(12f, -0.1f), Quaternion.identity);
			}
		}
		else
		{
			// サボテン(70%)
			int roop = Mathf.Min(cactusNum[Random.Range(0, cactusNum.Length)], GameDirectorSc.Instance.score / 100 + 1);
			float posX = 12f;

			for (int i = 0; i < roop; i++)
			{
				GameObject cactus = cactusList[Random.Range(0, cactusList.Length)];
				SpriteRenderer render = cactus.GetComponent<SpriteRenderer>();
				posX += render.bounds.size.x / 2f + 0.025f;
				Instantiate(cactus, new Vector2(posX, -0.5f), Quaternion.identity);
				posX += render.bounds.size.x / 2f + 0.025f;
			}

		}
	}


}
