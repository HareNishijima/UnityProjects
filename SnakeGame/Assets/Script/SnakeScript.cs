using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{


    public Vector2 move;
    

    public Vector2 SnakeDest()
    {
        GetComponent<Animator>().SetTrigger("Destroy");
        return move;
    }


}
