using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtonSc : MonoBehaviour
{

	public GameObject optionWindowObj;


	public void ButtonPush()
	{
		optionWindowObj.SetActive(!optionWindowObj.activeSelf);
	}
}
