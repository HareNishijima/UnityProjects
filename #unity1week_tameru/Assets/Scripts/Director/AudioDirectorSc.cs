using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirectorSc : MonoBehaviour
{

	private static AudioDirectorSc instance;
	private AudioSource audioSource;

	void Awake()
	{
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

	// Singletonインスタンスを取得する
	public static AudioDirectorSc GetInstance()
	{
		return instance;
	}

	// 指定されたクリップを再生する
	public void PlayClip(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}

	// クリップを停止する
	public void StopClip()
	{
		audioSource.Stop();
	}

	// 音源を再生する関数の呼び出し
	public static void Play(AudioClip clip)
	{
		GetInstance().PlayClip(clip);
	}

	// 音源を停止する関数の呼び出し
	public static void Stop()
	{
		GetInstance().StopClip();
	}

}
