using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirectorSc : MonoBehaviour
{

	public GameObject playerObj;
	public GameObject kingObj;

	public Text distanceText;
	public Text messageText;

	public Slider guageSlider;

	public GameObject retryBtnObj;

	float distance;

	// Update is called once per frame
	void Update()
	{
		if (kingObj != null)
		{
			distance = Mathf.Max((kingObj.transform.position.x - playerObj.transform.position.x) / 2f, 0f);
			distanceText.text = "殿様まで　あと" + distance.ToString("000.000") + "m";
		}
		else
		{
			distanceText.text = "残念！";
		}


	}

	public void ToReady()
	{
		retryBtnObj.SetActive(false);
	}

	public void ToCanRetry()
	{
		retryBtnObj.SetActive(true);
	}


	public void Message(string str)
	{
		messageText.text = str;
	}

	public void UpdateGuageSlider(float power)
	{
		guageSlider.value = power;
	}

}
