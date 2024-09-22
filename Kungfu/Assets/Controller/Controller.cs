using System;
using UnityEngine;

public class Controller
{
    public Vector2 GetAxisRaw()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool GetFire1()
    {
        return Input.GetButton("Fire1");
    }
}