using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSc : MonoBehaviour
{
	float initPosY;
	float speed;

	// Start is called before the first frame update
	void Start()
	{
		initPosY = transform.position.y;
		speed = 0.2f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.position = new Vector2(transform.position.x - GameDirectorSc.Instance.gameSpeed * Time.deltaTime * speed, initPosY);
	}
}
