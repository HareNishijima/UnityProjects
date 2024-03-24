using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirectorScript : MonoBehaviour
{
    private static AudioDirectorScript instance;
    private AudioSource audio_source;

    // Use this for initialization
    void Awake()
    {
        instance = this;
        audio_source = GetComponent<AudioSource>();
    }

    // Singletonインスタンスを取得する
    public static AudioDirectorScript GetInstance()
    {
        return instance;
    }

    // 指定されたクリップを再生する
    public void PlayClip(AudioClip clip)
    {
        audio_source.PlayOneShot(clip);
    }

    // 指定されたクリップを再生する
    public static void Play(AudioClip clip)
    {
        GetInstance().PlayClip(clip);
    }

    //音楽の停止
    public static void Stop(){
        GetInstance().audio_source.Stop();
    }


}
