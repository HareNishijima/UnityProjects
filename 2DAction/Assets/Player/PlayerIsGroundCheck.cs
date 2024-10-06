using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIsGroundCheck : MonoBehaviour
{
    [SerializeField] ContactFilter2D contactFilter2d;

    public bool isGroundCheck()
    {
        return GetComponent<Rigidbody2D>().IsTouching(contactFilter2d);
    }
}
