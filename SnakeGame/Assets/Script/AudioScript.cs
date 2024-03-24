using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private static AudioScript instance;
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Singletonインスタンスを取得する
    public static AudioScript GetInstance()
    {
        return instance;
    }

    // 指定されたクリップを再生する
    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // 指定されたクリップを再生する
    public static void Play(AudioClip clip)
    {
        GetInstance().PlayClip(clip);
    }

}
