using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startline : MonoBehaviour
{

    SceneDirector sceneDirector;

    // Start is called before the first frame update
    void Start()
    {
        sceneDirector = GameObject.FindWithTag("Director").GetComponent<SceneDirector>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        sceneDirector.ToPlay();
        GameObject.FindWithTag("Deadline").GetComponent<Deadline>().enabled = true;
    }
}
