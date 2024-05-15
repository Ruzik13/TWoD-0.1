using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	BoxCollider2D collider;
	CircleCollider2D circle;
	FlyingEyeHealth healthComponent;
	bool isHurting, isDead;
	bool facingRight = true;
	Vector3 localScale;
	float dirX;

	private EnemyPatrol enemyPatrol;

	void Update()
	{
		dirX = Input.GetAxisRaw("Horizontal");

		if (enemyPatrol != null)
			enemyPatrol.enabled = !isDead;

	}



	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		collider = GetComponent<BoxCollider2D>();
		circle = GetComponent<CircleCollider2D>();
		localScale = transform.localScale;
		enemyPatrol = GetComponentInParent<EnemyPatrol>();
		healthComponent = GetComponent<FlyingEyeHealth>();
		isDead = false;
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



	private void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.name.Equals("Human") && !isDead)
		{
			if (healthComponent.currentHealth < 1)
			{
				dirX = 0;
				isDead = true;
				anim.SetTrigger("isDead"); // Memainkan animasi kematian
				rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
				rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
				rb.isKinematic = false;
				circle.enabled = false;
			}

			else
			{
				StartCoroutine(Hurt(col));
			}
		}
	}

	IEnumerator Hurt(Collider2D col)
	{
		isHurting = true;
		rb.velocity = Vector2.zero;
		enemyPatrol.notmove();
		if (facingRight)
			rb.AddForce(new Vector2(-100f, 200f));
		else
			rb.AddForce(new Vector2(100f, 200f));
		anim.SetTrigger("isAttacking"); // Memainkan animasi terluka
		yield return new WaitForSeconds(1.5f);

		isHurting = false;
		enemyPatrol.Awake();

		HumanHealth humanHealth = col.gameObject.GetComponent<HumanHealth>();
		if (humanHealth != null && humanHealth.currentHealth <= 0)
		{
			anim.SetBool("isFlying", false);
			enemyPatrol.notmove();
		}
	}
}
