﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;
	float dirX, Speed;
    public float moveSpeedwalk = 3f;
    public float moveSpeedrun = 8f;
	HumanHealth healthComponent;
    RatHealth enemyhealthComponent;
    MonsterHealth enemyhealth2Component;
    bool isHurting, isDead;
    bool facingRight = true;
	Vector3 localScale;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		localScale = transform.localScale;
        healthComponent = GetComponent<HumanHealth> ();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
			rb.AddForce(Vector2.up * 600f);

		if (Input.GetKey(KeyCode.LeftShift))
            Speed = moveSpeedrun;
		else
            Speed = moveSpeedwalk;

		SetAnimationState();

		if (!isDead)
			dirX = Input.GetAxisRaw("Horizontal") * Speed;


        if (Input.GetKey(KeyCode.S))
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }

    void PlayerAttack()
    {
        if (Input.GetKey(KeyCode.S))
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }

    void FixedUpdate()
	{
		if (!isHurting)
			rb.velocity = new Vector2 (dirX, rb.velocity.y);
	}

	void LateUpdate()
	{
		CheckWhereToFace();
	}

	void SetAnimationState()
	{
		if (dirX == 0) {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRunning", false);
		}

		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", false);
		}

		if (Mathf.Abs(dirX) == 3 && rb.velocity.y == 0)
			anim.SetBool ("isWalking", true);
		
		if (Mathf.Abs(dirX) == 8 && rb.velocity.y == 0)
			anim.SetBool ("isRunning", true);
		else
			anim.SetBool ("isRunning", false);

		if (rb.velocity.y > 0)
			anim.SetBool ("isJumping", true);
		
		if (rb.velocity.y < 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", true);
		}
    }

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals("rat") && !isDead) {
            if (healthComponent.GetHealthPoints() <= 0)
            {
                dirX = 0;
                isDead = true;
                anim.SetTrigger("isDead"); // Memainkan animasi kematian
            }
            else if (Input.GetKey(KeyCode.S))
            {
                col.GetComponent<RatHealth>().DecreaseHealth();
                anim.SetBool("isAttacking", true);
            }
            else if (col.gameObject.GetComponent<RatHealth>().GetHealthPoints() <= 0)
			{
			}
            else 
            {
                healthComponent.DecreaseHealth();
                anim.SetBool("isAttacking", false);
                anim.SetTrigger("isHurting"); // Memainkan animasi terluka
                StartCoroutine(Hurt());
            }             
        }
        if (col.gameObject.name.Equals("Bringer-of-Death") && !isDead)
        {
            if (healthComponent.GetHealthPoints() <= 0)
            {
                dirX = 0;
                isDead = true;
                anim.SetTrigger("isDead"); // Memainkan animasi kematian
            }
            else if (Input.GetKey(KeyCode.S))
            {
                col.GetComponent<MonsterHealth>().DecreaseHealth();
                anim.SetBool("isAttacking", true);
            }
            else if (col.gameObject.GetComponent<MonsterHealth>().GetHealthPoints() <= 0)
            {
            }
            else
            {
                healthComponent.DecreaseHealth();
                anim.SetBool("isAttacking", false);
                anim.SetTrigger("isHurting"); // Memainkan animasi terluka
                StartCoroutine(Hurt());
            }
        }
        if (col.gameObject.name.Equals("Suriken") && !isDead)
		{
			if (healthComponent.GetHealthPoints() <= 0)
			{
				dirX = 0;
				isDead = true;
				anim.SetTrigger("isDead"); // Memainkan animasi kematian
			}
			else { 
			healthComponent.DecreaseHealth();
			anim.SetTrigger("isHurting"); // Memainkan animasi terluka
			StartCoroutine(Hurt());
			}
        }

    }

	IEnumerator Hurt()
	{
		isHurting = true;
		rb.velocity = Vector2.zero;

		if (facingRight)
			rb.AddForce (new Vector2(-200f, 200f));
		else
			rb.AddForce (new Vector2(200f, 200f));
		
		yield return new WaitForSeconds (0.5f);

		isHurting = false;
	}

}