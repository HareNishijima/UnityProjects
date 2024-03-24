using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSc : MonoBehaviour
{

	float initPosY;

	// Start is called before the first frame update
	void Start()
	{
		initPosY = transform.position.y;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.position = new Vector2(transform.position.x - GameDirectorSc.Instance.gameSpeed * Time.deltaTime, initPosY);
	}
}
