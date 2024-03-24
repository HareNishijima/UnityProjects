using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonSc : MonoBehaviour
{

	public AudioClip pafu;

	public void ToRetry()
	{
		SceneManager.LoadScene("Main");
		AudioDirectorSc.Play(pafu);
	}
}
