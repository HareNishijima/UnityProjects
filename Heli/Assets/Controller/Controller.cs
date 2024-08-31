using UnityEngine;

public class Controller
{
    public Vector2 MoveInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
