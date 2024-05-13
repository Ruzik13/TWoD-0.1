using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class Human : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;
	float dirX, Speed;
    public float moveSpeedwalk = 4f;
    public float moveSpeedrun = 8f;
	HumanHealth healthComponent;
    RatHealth enemyhealthComponent;
    MonsterHealth enemyhealth2Component;
	private float idleTimer = 0;
	private float idleDuration = 100;
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
			rb.AddForce(Vector2.up * 700f);

		if (Input.GetKey(KeyCode.LeftShift))
            Speed = moveSpeedrun;
		else
            Speed = moveSpeedwalk;

		SetAnimationState();

		if (!isDead)
			dirX = Input.GetAxisRaw("Horizontal") * Speed;


        if (Input.GetKeyDown(KeyCode.S))
		{
			anim.SetBool("isAttacking", true);
			StartCoroutine(EndAttack());

		}

		if (healthComponent.currentHealth <= 0)
		{
			dirX = 0;
			isDead = true;
			anim.SetTrigger("isDead"); // Memainkan animasi kematian
			Load_GameOver();
		}
		

	}

	IEnumerator EndAttack()
	{
		yield return new WaitForSeconds(0.5f); // Задержка, соответствующая длительности анимации
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
		
		
		
		
	
		if (dirX == 0) 
		{
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRunning", false);
		}

		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", false);
		}

		if (Mathf.Abs(dirX) == moveSpeedwalk && rb.velocity.y == 0)
		{
			anim.SetBool("isWalking", true);
			anim.SetBool("isRunning", false);
		}
			
	
		if (Mathf.Abs(dirX) == moveSpeedrun && rb.velocity.y == 0)
		{
			anim.SetBool("isRunning", true);
			anim.SetBool("isWalking", false);
		}
			

		if (rb.velocity.y > 0 && Input.GetKey(KeyCode.Space))
			anim.SetBool ("isJumping", true);



		
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
            if (healthComponent.currentHealth <= 0)
            {
                dirX = 0;
                isDead = true;
                anim.SetTrigger("isDead"); // Memainkan animasi kematian
				Load_GameOver();
			}
            else if (Input.GetKey(KeyCode.S))
            {
                col.GetComponent<RatHealth>().DecreaseHealth(1);
                anim.SetBool("isAttacking", true);
            }
            else if (col.gameObject.GetComponent<RatHealth>().currentHealth <= 0)
			{
			}
            else 
            {
                StartCoroutine(Hurt(1));
            }             
        }
        if (col.gameObject.name.Equals("Bringer-of-Death") && !isDead)
        {
            if (healthComponent.currentHealth <= 0)
            {
                dirX = 0;
                isDead = true;
                anim.SetTrigger("isDead"); // Memainkan animasi kematian
				Load_GameOver();
			}
            else if (Input.GetKey(KeyCode.S))
            {
                col.GetComponent<MonsterHealth>().DecreaseHealth(1);
                anim.SetBool("isAttacking", true);
            }
            else if (col.gameObject.GetComponent<MonsterHealth>().currentHealth <= 0)
            {
            }
            else
            {
                StartCoroutine(Hurt(1));
            }
        }
        if (col.gameObject.name.Equals("Skeleton") && !isDead)
		{
			if (healthComponent.currentHealth <= 0)
			{
				dirX = 0;
				isDead = true;
				anim.SetTrigger("isDead"); // Memainkan animasi kematian
				Load_GameOver();
			}

			else if (Input.GetKey(KeyCode.S))
			{
				col.GetComponent<SkeletonHealth>().DecreaseHealth(1);
				anim.SetBool("isAttacking", true);
			}
			else if (col.gameObject.GetComponent<SkeletonHealth>().currentHealth <= 0)
			{
			}
			else { 
			
				StartCoroutine(Hurt(1)); 
			}
        }

    }

	IEnumerator Hurt(float _damage)
	{
		isHurting = true;
		rb.velocity = Vector2.zero;

		if (facingRight)
			rb.AddForce(new Vector2(-200f, 200f));
		else
			rb.AddForce(new Vector2(200f, 200f));

		yield return new WaitForSeconds(1.5f);
		anim.SetTrigger("isHurting"); 
		healthComponent.DecreaseHealth(_damage);
		isHurting = false;
	}

	public void Load_GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}

}
