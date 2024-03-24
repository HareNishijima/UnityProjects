using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallSc : MonoBehaviour
{

	public BackGroundGenerator backGroundGeneratorSc;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "BackGround")
		{
			backGroundGeneratorSc.BackGroundGenerate(col.gameObject.transform.position.x);
		}
		Destroy(col.gameObject);
	}
}
