using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallSc : MonoBehaviour
{

	DestroyAndGenerateStageSc destroyAndGenerateStageSc;
	GenerateEnemySc generateEnemySc;

	// Start is called before the first frame update
	void Start()
	{
		destroyAndGenerateStageSc = GetComponent<DestroyAndGenerateStageSc>();
		generateEnemySc = GetComponent<GenerateEnemySc>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			generateEnemySc.GenerateEnemy(col);

		}
		else
		{
			destroyAndGenerateStageSc.GenerateStage(col);
		}

	}
}
