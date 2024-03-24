using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    public AudioClip StageSound;
    private int size = GameDirector.Size;
    private float var;

    void Start()
    {
        var = size + 1.5f;
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(var,var));
        this.transform.localScale = new Vector3(var*2,0.5f,var*2);
        GetComponent<AudioSource>().PlayOneShot(StageSound);
    }

    void Update()
    {
        if (this.transform.position.y >= -0.2f)
        {
            this.transform.Translate(0f, -0.1f, 0f);
        }
    }



}
