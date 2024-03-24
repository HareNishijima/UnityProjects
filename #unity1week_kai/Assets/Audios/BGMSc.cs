using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSc : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip audio_clip;

    void Awake()
    {

        AudioSource audio_source=GetComponent<AudioSource>();
        audio_source.clip=audio_clip;
        audio_source.Play();
    }

}
