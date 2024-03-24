using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIDirectorSc : SingletonMonoBehaviour<UIDirectorSc>
{

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI hiScoreText;
	public TextMeshProUGUI mainText;

	public void UpdateScoreText(int score)
	{
		scoreText.SetText(score.ToString("00000"));
	}

	public void UpdateHiScoreText(int hiScore)
	{
		if (hiScore == 0) return;
		hiScoreText.SetText("HI " + hiScore.ToString("00000"));
	}

	public void ToPlay()
	{
		mainText.enabled = false;
	}

	public void ToMiss()
	{
		mainText.enabled = true;
		mainText.SetText("GAME OVER");
	}

}
