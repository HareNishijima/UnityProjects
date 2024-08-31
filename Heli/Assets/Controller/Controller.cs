using System;
using UnityEngine;

public class Controller
{
    Vector2 adjustedInput;
    float speed;

    public Controller()
    {
        adjustedInput = Vector2.zero;
        speed = 5f;
    }
    public Vector2 RawInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    public Vector2 AdjustedInput()
    {
        Vector2 rawInput = RawInput();

        adjustedInput.x = Mathf.MoveTowards(adjustedInput.x, Math.Sign((int)rawInput.x), speed * Time.deltaTime);
        adjustedInput.y = Mathf.MoveTowards(adjustedInput.y, Math.Sign((int)rawInput.y), speed * Time.deltaTime);

        return adjustedInput;
    }
}
