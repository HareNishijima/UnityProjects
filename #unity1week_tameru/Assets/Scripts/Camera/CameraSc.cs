using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc : MonoBehaviour
{

	public Transform playerTra;
	Vector3 offsetPos;

	// Start is called before the first frame update
	void Start()
	{
		offsetPos = playerTra.position - transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		transform.position = new Vector3(playerTra.position.x - offsetPos.x, transform.position.y, transform.position.z);

	}
}
