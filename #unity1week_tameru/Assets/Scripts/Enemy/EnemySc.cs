using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour
{

	Animator anim;
	public GameObject par;
	public AudioClip slashedAudio;

	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void Dead()
	{
		anim.SetTrigger("Dead");
		Instantiate(par, transform.position, Quaternion.identity);
		AudioDirectorSc.Play(slashedAudio);
	}
}
