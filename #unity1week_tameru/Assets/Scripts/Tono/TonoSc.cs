using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonoSc : MonoBehaviour
{
	public static int tonoPosIdx = 0;

	Animator anim;
	public GameObject par;
	public AudioClip slashed;

	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		float[] PosXList = new float[4] { 200, 100, 300, 400 };
		transform.position = new Vector3(PosXList[tonoPosIdx], 0f, 0f);
	}

	public void Dead()
	{
		anim.SetTrigger("Dead");
		Instantiate(par, transform.position, Quaternion.identity);
		AudioDirectorSc.Play(slashed);
	}
}
