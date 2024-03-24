using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSc : MonoBehaviour
{
	public ParticleSystem chargePar;
	public AudioClip chargeAudio;

	GameDirectorSc gameDirectorSc;
	UIDirectorSc uiDirectorSc;
	Rigidbody2D rb;
	Animator anim;

	float power;
	bool isAttack;
	bool isFinish;
	float speed;

	Vector3 pos;
	ParticleSystem instaPar;


	// Start is called before the first frame update
	void Start()
	{
		isAttack = false;
		isFinish = false;
		speed = 50f;

		gameDirectorSc = GameObject.FindGameObjectWithTag("Director").GetComponent<GameDirectorSc>();
		uiDirectorSc = GameObject.FindGameObjectWithTag("Director").GetComponent<UIDirectorSc>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isAttack) return;

		if (Input.GetMouseButtonDown(0))
		{
			instaPar = Instantiate(chargePar, transform.position, Quaternion.Euler(90f, 0f, 0f));
			AudioDirectorSc.Play(chargeAudio);
		}
		if (Input.GetMouseButton(0))
		{
			Charge();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			AudioDirectorSc.Stop();
			Attack();
		}
	}

	void FixedUpdate()
	{
		pos = transform.position;
		if (!isAttack) return;

		rb.MovePosition(pos + new Vector3(power * speed, 0f, 0f) * Time.deltaTime);
		power = Mathf.Clamp(power - Time.deltaTime, 0f, power);

		if (power <= 0f)
		{
			Finish();
		}
	}
	void Charge()
	{
		power = Mathf.Clamp(power + Time.deltaTime, 0f, 5f);
		uiDirectorSc.UpdateGuageSlider(power);
		anim.speed = power;
	}

	void Attack()
	{
		isAttack = true;
		Destroy(instaPar.gameObject);
		anim.SetTrigger("Attack");
	}

	void Finish()
	{
		if (isFinish) return;


		isFinish = true;
		gameDirectorSc.ToFinish();
	}

	void End()
	{
		speed = 5f;
		power = Mathf.Min(1f, power);
		gameDirectorSc.ToGameOver();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Tono")
		{
			col.gameObject.GetComponent<TonoSc>().Dead();

			End();
		}
		else if (col.gameObject.tag == "Enemy")
		{
			col.gameObject.GetComponent<EnemySc>().Dead();
		}
	}
}
