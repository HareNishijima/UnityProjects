using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator animator;
    PlayerTransform playerTransform;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<PlayerTransform>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    public void Animation()
    {
        Vector2 moveVec = playerTransform.GetPlayerVector();
        Vector2 jumpVec = playerTransform.GetPlayerVector();

        animator.SetFloat("XSpeed", Mathf.Abs(moveVec.x));
        animator.SetFloat("YSpeed", jumpVec.y);

        animator.SetBool("IsGround", playerState.IsGround());
        animator.SetBool("IsJumpCharge", playerState.IsJumpCharge());
    }

    public void ToDead()
    {
        animator.SetBool("IsDead", true);
    }
}
