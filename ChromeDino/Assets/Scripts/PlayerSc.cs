using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSc : MonoBehaviour
{
	public float maxJumpForce; // 初速
	public float minJumpForce; // 終端速度
	public float decJumpForce; // 減速率(重力)
	public AudioClip jumpSE;
	public AudioClip missSE;
	Animator animator;

	float jumpForce;
	Vector2 pos;
	Vector2 prevPos;

	float devJumpForceRate;
	float maxJumpForceRate;

	Rigidbody2D rb;

	enum State { Idle, Stand, Jump, Stoop, Miss }
	State state;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		state = State.Stand;
		pos = rb.position;
		prevPos = pos;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			// 立ち状態
			case State.Stand:
				InputStand();
				break;
			// ジャンプ状態
			case State.Jump:
				InputJump();
				break;
			// しゃがみ状態
			case State.Stoop:
				InputStoop();
				break;
		}
	}

	void FixedUpdate()
	{
		switch (state)
		{
			// ジャンプ状態
			case State.Jump:
				Jump();
				break;
		}
		// 座標更新
		rb.position = pos;
	}

	void InputStand()
	{
		// しゃがみ
		if (Input.GetKey("down"))
		{
			state = State.Stoop;
			animator.SetBool("Stoop", true);
		}
		// ジャンプ
		else if (Input.GetButton("Jump"))
		{
			state = State.Jump;
			animator.SetTrigger("Jump");
			AudioDirectorSc.Play(jumpSE);
			jumpForce = maxJumpForce;
		}
	}

	void InputJump()
	{
		devJumpForceRate = 1f;
		maxJumpForceRate = 1f;

		if (Input.GetKey("down"))
		{
			// 高速落下
			devJumpForceRate = 3f;
			maxJumpForceRate = 0f;
		}


	}

	void Jump()
	{
		// マリオジャンプ処理
		jumpForce = Mathf.Clamp(jumpForce - decJumpForce * devJumpForceRate, minJumpForce, maxJumpForce * maxJumpForceRate);
		prevPos = pos;
		pos += new Vector2(0f, rb.position.y - prevPos.y + jumpForce) * Time.deltaTime;

		// 着地チェック
		if (jumpForce <= 0 && pos.y <= 0)
		{
			state = State.Stand;
			animator.SetTrigger("Stand");
			jumpForce = 0f;
			pos = Vector2.zero;
			prevPos = pos;
		}
	}

	void InputStoop()
	{
		// しゃがみ解除
		if (Input.GetKeyUp("down"))
		{
			state = State.Stand;
			animator.SetBool("Stoop", false);
		}
	}

	public void ToPlay()
	{
		state = State.Stand;
		rb.transform.position = Vector2.zero;
		animator.Play("Stand");
	}

	void Miss()
	{
		state = State.Miss;
		animator.SetTrigger("Miss");
		AudioDirectorSc.Play(missSE);
		GameDirectorSc.Instance.ToMiss();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Object")
		{
			Miss();
		}

	}


}

