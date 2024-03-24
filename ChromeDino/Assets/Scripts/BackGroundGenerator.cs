using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
	public GameObject[] backGrondList;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = -2; i < 15; i++)
		{
			Instantiate(backGrondList[Random.Range(0, backGrondList.Length)], new Vector2(i * 1f, -0.2f), Quaternion.identity);
		}
	}

	public void BackGroundGenerate(float x)
	{
		Instantiate(backGrondList[Random.Range(0, backGrondList.Length)], new Vector2(x + 16f, -0.2f), Quaternion.identity);
	}

}
