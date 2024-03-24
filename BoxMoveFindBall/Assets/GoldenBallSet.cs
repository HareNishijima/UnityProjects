using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBallSet : MonoBehaviour
{

    public AudioClip StageSound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(StageSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 0.5f)
        {
            this.transform.Translate(0.0f, -0.1f, 0.0f);
        }
    }
}
