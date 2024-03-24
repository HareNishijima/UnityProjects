using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = GameDirectorScript.anim_speed;

    }

    public void Dest()
    {
        animator.SetTrigger("Destroy");
    }


    public void DestEvent()
    {
        Destroy(this.gameObject);
    }
}
