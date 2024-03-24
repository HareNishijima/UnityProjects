using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorSc : MonoBehaviour
{

	UIDirectorSc uiDirectorSc;

	string state;

	public AudioClip clearAudio;
	public AudioClip missAudio;

	void Start()
	{
		state = "Start";
		uiDirectorSc = GetComponent<UIDirectorSc>();

		ToReady();
	}

	public void ToReady()
	{
		state = "Ready";
		uiDirectorSc.ToReady();
	}

	public void ToFinish()
	{
		if (state == "GameOver") return;

		state = "Finish";

		float tonoPosX = GameObject.FindGameObjectWithTag("Tono").transform.position.x;
		float playerPosX = GameObject.FindGameObjectWithTag("Player").transform.position.x;

		if (tonoPosX - playerPosX > 11f)
		{
			ToMiss();
		}
		else if (tonoPosX - playerPosX > 0f)
		{
			ToClear();
		}

		StartCoroutine(ToCanRetryCoroutine());

	}

	public void ToClear()
	{
		state = "Clear";
		uiDirectorSc.Message("あっぱれ！");
		AudioDirectorSc.Play(clearAudio);
		TonoSc.tonoPosIdx = (TonoSc.tonoPosIdx + 1) % 4;
		Debug.Log(TonoSc.tonoPosIdx);
	}

	public void ToMiss()
	{
		state = "Miss";
		AudioDirectorSc.Play(missAudio);
		uiDirectorSc.Message("全員倒せてないぞ！");
	}

	public void ToGameOver()
	{
		state = "GameOver";
		uiDirectorSc.Message("ぐわーっ！！");
		StartCoroutine(ToCanRetryCoroutine());
	}

	IEnumerator ToCanRetryCoroutine()
	{
		yield return new WaitForSeconds(2f);
		uiDirectorSc.ToCanRetry();
	}

}
