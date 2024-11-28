using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{

    public float speed = 1f;
    SceneDirector sceneDirector;

    // Start is called before the first frame update
    void Start()
    {
        sceneDirector = GameObject.FindWithTag("Director").GetComponent<SceneDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneDirector.IsGameOver()) return;
        transform.position += new Vector3(0f, speed, 0f) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sceneDirector.ToGameOver();
            col.gameObject.GetComponent<PlayerState>().ToDead();
            speed = 0f;
        }
    }
}
