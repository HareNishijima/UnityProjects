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
    void Update()
    {
        Vector2 moveVec = playerTransform.GetMoveVector();
        Vector2 jumpVec = playerTransform.GetJumpVector();

        animator.SetFloat("XSpeed", Mathf.Abs(moveVec.x));
    }
}
