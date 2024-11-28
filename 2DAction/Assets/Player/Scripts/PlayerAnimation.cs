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
        Vector2 moveVec = playerTransform.GetMoveVector();
        Vector2 jumpVec = playerTransform.GetJumpVector();

        animator.SetFloat("XSpeed", Mathf.Abs(moveVec.x));
        animator.SetFloat("YSpeed", jumpVec.y);

        animator.SetBool("IsGround", playerState.IsGround());
        animator.SetBool("IsCharge", playerState.IsCharge());
    }

    public void ToDead()
    {
        animator.SetBool("IsDead", true);
    }
}
