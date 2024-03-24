using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public GameObject Camera;
    private bool push = false;

    public AudioClip StartSound;

    void Update()
    {
        if(push){
            Camera.transform.Rotate(0.5f, 0f, 0f);
            if(Camera.transform.localEulerAngles.x>=90){
                Camera.transform.localEulerAngles =new Vector3(90,0,0);
                SceneManager.LoadScene("Main");  
            }
        }


    }

    // Start is called before the first frame update
    public void StartButton()
    {      
        push = true;
        GetComponent<AudioSource>().PlayOneShot(StartSound);
    }
    
}
