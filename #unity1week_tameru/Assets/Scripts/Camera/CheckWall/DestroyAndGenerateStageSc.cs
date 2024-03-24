using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndGenerateStageSc : MonoBehaviour
{
	public GameObject stageWhite;
	public GameObject stageGray;

	Transform poolTra;

	void Start()
	{
		poolTra = new GameObject("StagePool").transform;
		Instantiate(stageWhite, new Vector3(-10f, -1.5f, 0f), Quaternion.identity, poolTra);
		Instantiate(stageGray, new Vector3(0f, -1.5f, 0f), Quaternion.identity, poolTra);
		Instantiate(stageWhite, new Vector3(10f, -1.5f, 0f), Quaternion.identity, poolTra);
		Instantiate(stageGray, new Vector3(20f, -1.5f, 0f), Quaternion.identity, poolTra);
	}

	public void GenerateStage(Collider2D col)
	{

		col.transform.SetPositionAndRotation(new Vector3(col.transform.position.x + 40f, -1.5f, 0f), Quaternion.identity);
	}
}
