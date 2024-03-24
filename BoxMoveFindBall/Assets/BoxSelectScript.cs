using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelectScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public AudioClip SoundGood;

    // Start is called before the first frame update
    public void BoxSelect(){
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        foreach(RaycastHit hit in Physics.RaycastAll(ray.origin,ray.direction,30f)){
            if (hit.collider.gameObject.tag == "Box")
                hit.collider.gameObject.transform.Rotate(0f, 10f, 0f);

            if (Input.GetKey("mouse 0")){               
                if (hit.collider.gameObject.tag == "GoldenBall"){
                    GameDirector.Ball_count++;
                    GetComponent<AudioSource>().PlayOneShot(SoundGood);
                    hit.collider.gameObject.tag = "Selected";
                }
                else if (hit.collider.gameObject.tag == "Box")
                {
                    GameDirector.penalty++;
                    Destroy(hit.collider.gameObject);
                }
            }       
            
        }
    }
}