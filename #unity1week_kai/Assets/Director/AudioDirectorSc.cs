using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirectorSc : MonoBehaviour
{
    public AudioClip[] audio_array;
    AudioSource audio_source;

    void Start(){
        audio_source=GetComponent<AudioSource>();
    }

    public void AudioOneShot(int n){
        audio_source.PlayOneShot(audio_array[n]);
    }


}
