using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoveScript : MonoBehaviour
{

    private Vector3 ray;
    private Vector3 vec;
    private int size;


    public void BoxMove(int pos, int sel)
    {
        size = GameDirector.Size;
        switch (sel)
        {
            case 1:
                ray = new Vector3(pos, 0.5f, -size-2);
                vec = new Vector3(0.0f, 0.0f, 1.0f);
                break;
            case 2:
                ray = new Vector3(size+2, 0.5f, pos);
                vec = new Vector3(-1.0f, 0.0f, 0.0f);
                break;
            case 3:
                ray = new Vector3(pos, 0.5f, size+2);
                vec = new Vector3(0.0f, 0.0f, -1.0f);
                break;
            case 4:
                ray = new Vector3(-size-2, 0.5f, pos);
                vec = new Vector3(1.0f, 0.0f, 0.0f);
                break;
        }

        Debug.DrawRay(ray, vec * size * 4, Color.red, 5.0f);

       

        foreach (RaycastHit hit in Physics.RaycastAll(ray, vec, size * 4)){
            hit.collider.gameObject.transform.Translate(vec / 10);
        }   

       
    }
 

}
