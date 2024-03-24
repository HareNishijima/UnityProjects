using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSetScript : MonoBehaviour
{

    public GameObject WhiteBox;
    public GameObject BlackBox;
    private int size;
    private bool select = false;
    private int[,] array = new int[10, 10];

    public void BoxSet()
    {
        size = GameDirector.Size;

        for (int i = -size; i <= size; i++)
        {       
            for(int j = -size; j <= size; j++){
                if(select)
                    Instantiate(BlackBox, new Vector3(j, 7.0f, i), Quaternion.identity);
                else
                    Instantiate(WhiteBox, new Vector3(j, 7.0f, i), Quaternion.identity);
                select = !select;

            }          
        }
    }
    
}
