using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DirectionRight(bool b)
    {
        // スプライトが元々右向きなので、右を向く場合はflipXはfalseになる
        spriteRenderer.flipX = !b;
    }
}
