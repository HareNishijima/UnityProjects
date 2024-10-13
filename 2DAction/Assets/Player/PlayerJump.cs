using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float maxHeightToTime;
    public float maxHeight;
    PlayerTransform playerTransform;

    float currentHeight;

    bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        isGround = true;
        playerTransform = GetComponent<PlayerTransform>();
        currentHeight = transform.position.y;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (!isGround)
        {
            if (currentHeight >= maxHeight)
            {
                isGround = true;
                return;
            }
            currentHeight = Mathf.MoveTowards(currentHeight, maxHeight, maxHeight * maxHeightToTime * Time.fixedDeltaTime);
            playerTransform.SetHeight(currentHeight);
        }
    }

    public void Jump()
    {
        isGround = false;
        currentHeight = transform.position.y;
    }
}
