using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorSc : SingletonMonoBehaviour<GameDirectorSc>
{

	public int score;
	public int hiScore;
	public float gameSpeed;
	public enum State { Title, Play, Miss };
	public State state;
	public AudioClip scoreSE;

	void Awake()
	{
		score = 0;
		hiScore = 0;
		gameSpeed = 0f;
		state = State.Title;
	}

	// Update is called once per frame
	void Update()
	{

		switch (state)
		{
			case State.Title:
				if (Input.GetButtonDown("Jump"))
				{
					ToPlay();
				}
				break;
			case State.Miss:
				if (Input.GetButtonDown("Jump"))
				{
					Reset();
				}
				break;
		}
	}

	void ToPlay()
	{
		state = State.Play;
		gameSpeed = 8f;
		UIDirectorSc.Instance.ToPlay();
		StartCoroutine(Coroutine());
	}

	public void ToMiss()
	{
		state = State.Miss;
		gameSpeed = 0f;
		UIDirectorSc.Instance.ToMiss();
	}

	void Reset()
	{
		if (score > hiScore) hiScore = score;
		UIDirectorSc.Instance.UpdateHiScoreText(hiScore);
		score = 0;
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Object");
		foreach (GameObject obj in objs)
		{
			Destroy(obj);
		}
		PlayerSc playerSc = GameObject.FindWithTag("Player").GetComponent<PlayerSc>();
		playerSc.ToPlay();

		ToPlay();
	}

	IEnumerator Coroutine()
	{
		while (true)
		{
			score += 1;
			if (score % 100 == 0)
			{
				gameSpeed += 2f;
				AudioDirectorSc.Play(scoreSE);

			}
			UIDirectorSc.Instance.UpdateScoreText(score);
			yield return new WaitForSeconds(1f / gameSpeed);
		}
	}


}
