using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject particleObj;
    ParticleSc particle;

    private void Start() {
        particle = particleObj.GetComponent<ParticleSc>();
    }

    private void OnTriggerEnter(Collider other) {
        if(particle.IsPlay()){
            particle.Stop();
        }else{
            particle.Play();
        }
    }
}
