using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorScript : MonoBehaviour
{
    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        this.transform.position = pos;
    }
}
