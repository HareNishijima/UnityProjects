using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSc : MonoBehaviour
{

    ParticleSystem ps;

    private void Start() {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }

    public bool IsPlay(){
        return ps.isPlaying;
    }

    public void Play(){
        ps.Play();
    }

    public void Stop(){
        ps.Stop();
    }
}
