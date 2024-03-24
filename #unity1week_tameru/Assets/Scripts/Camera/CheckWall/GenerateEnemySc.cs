using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemySc : MonoBehaviour
{

	public GameObject enemyObj;

	Transform poolTra;

	float tonoPosX;

	void Start()
	{
		poolTra = new GameObject("EnemyPool").transform;
		for (int i = 1; i <= 4; i++)
		{
			Instantiate(enemyObj, new Vector3(i * 10f, 0f, 0f), Quaternion.identity, poolTra);
		}
		tonoPosX = GameObject.FindGameObjectWithTag("Tono").transform.position.x;
	}


	public void GenerateEnemy(Collider2D col)
	{
		if (col.transform.position.x + 40f >= tonoPosX) return;
		col.transform.SetPositionAndRotation(new Vector3(col.transform.position.x + 40f, 0f, 0f), Quaternion.identity);
		col.GetComponent<Animator>().Play("Idle");
	}
}
