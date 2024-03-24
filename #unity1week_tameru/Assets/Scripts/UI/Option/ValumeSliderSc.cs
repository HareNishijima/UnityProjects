using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValumeSliderSc : MonoBehaviour
{

	public AudioSource audioSource;
	Slider slider;

	void Start()
	{
		slider = GetComponent<Slider>();
		slider.value = AudioListener.volume;
	}

	public void ValumeSliderChange()
	{
		audioSource.volume = slider.value;
	}
}
