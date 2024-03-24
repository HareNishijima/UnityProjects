using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxScript : MonoBehaviour
{

    private Vector3 vec;
    private Vector3 check;
    private int size;

    public bool CheckBox(int pos, int sel)
    {
        size = GameDirector.Size;
        switch (sel)
        {
            case 1:
                vec = new Vector3(0.0f, 0.0f, 1.0f);
                check = new Vector3(pos, 0.5f, size);
                break;
            case 2:
                vec = new Vector3(-1.0f, 0.0f, 0.0f);
                check = new Vector3(-size, 0.5f, pos);
                break;
            case 3:
                vec = new Vector3(0.0f, 0.0f, -1.0f);
                check = new Vector3(pos, 0.5f, -size);
                break;
            case 4:
                vec = new Vector3(1.0f, 0.0f, 0.0f);
                check = new Vector3(size, 0.5f, pos);
                break;
        }

        Debug.DrawRay(check, vec, Color.blue, 5.0f);

        if (Physics.Raycast(check, vec))
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
