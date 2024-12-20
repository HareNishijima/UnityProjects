using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public SceneDirector sceneDirector;
    Timer timer;

    void Start()
    {
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sceneDirector.ToClear();
            GameObject.FindWithTag("Deadline").GetComponent<Deadline>().enabled = false;
            timer.SetActive(false);
        }
    }
}
