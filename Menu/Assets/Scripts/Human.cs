using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class Human : Sounds
{

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
	public float delayTime = 2.5f; // Таймаут до следующего срабатывания звука
	private float lastTriggerTime = 0f; // Время последнего срабатывания звука
	float hp;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		localScale = transform.localScale;
        healthComponent = GetComponent<HumanHealth> ();
		if(SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
		{
			if(PlayerPrefs.HasKey("Health") && PlayerPrefs.HasKey("NewLevel"))
		{
				hp = PlayerPrefs.GetFloat("Health");
				healthComponent.currentHealth = hp;
				PlayerPrefs.DeleteKey("NewLevel");
			}
		}
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
		{
            PlaySound(sounds[1]);
			rb.AddForce(Vector2.up * 700f);
        }

		if (Input.GetKey(KeyCode.LeftShift))
			Speed = moveSpeedrun;
		else
            Speed = moveSpeedwalk;

		SetAnimationState();

		if (!isDead)
			dirX = Input.GetAxisRaw("Horizontal") * Speed;


        if (Input.GetKeyDown(KeyCode.S))
		{
			PlaySound(sounds[2]);
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

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && rb.velocity.y == 0)
		{
			if(Input.GetKey(KeyCode.LeftShift))
				StartCoroutine(PlaySoundAfterDelay());


			else if (!audioSrc.isPlaying)
				PlaySound(sounds[0]);

		}
	}

	IEnumerator PlaySoundAfterDelay()
	{
		yield return new WaitForSeconds(delayTime);

		// Проверяем, что прошло достаточно времени с момента последнего срабатывания
		if (Time.time - lastTriggerTime > delayTime)
		{
			PlaySound(sounds[0]); // Запускаем звук
			lastTriggerTime = Time.time; // Обновляем время последнего срабатывания
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
		{
            anim.SetBool("isAttacking", true);
        }
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
			

		if (Input.GetKey(KeyCode.Space))
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
            else if (Input.GetKey(KeyCode.S) && col.GetComponent<RatHealth>().currentHealth > 0)
            {
                col.GetComponent<RatHealth>().DecreaseHealth(1);
                anim.SetBool("isAttacking", true);
            }
            else if (col.gameObject.GetComponent<RatHealth>().currentHealth <= 0)
			{
			}
            else 
            {
                StartCoroutine(Hurt(1, 0.1f));
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
            else if (Input.GetKey(KeyCode.S) && col.GetComponent<MonsterHealth>().currentHealth > 0 && SceneManager.GetActiveScene().buildIndex != 2)
            {
                col.GetComponent<MonsterHealth>().DecreaseHealth(1);
                anim.SetBool("isAttacking", true);
            }
            else if (col.gameObject.GetComponent<MonsterHealth>().currentHealth <= 0)
            {
            }
            else
            {
                StartCoroutine(Hurt(1, 0.5f));
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

			else if (Input.GetKey(KeyCode.S) && col.GetComponent<SkeletonHealth>().currentHealth > 0)
			{
				col.GetComponent<SkeletonHealth>().DecreaseHealth(1);
				anim.SetBool("isAttacking", true);
			}
			else if (col.gameObject.GetComponent<SkeletonHealth>().currentHealth <= 0)
			{
			}
			else { 
			
				StartCoroutine(Hurt(1, 2f)); 
			}
        }

		if (col.gameObject.name.Equals("FlyingEye") && !isDead)
		{
			if (healthComponent.currentHealth <= 0)
			{
				dirX = 0;
				isDead = true;
				anim.SetTrigger("isDead"); // Memainkan animasi kematian
				Load_GameOver();
			}

			else if (Input.GetKey(KeyCode.S) && col.GetComponent<FlyingEyeHealth>().currentHealth > 0)
			{
				col.GetComponent<FlyingEyeHealth>().DecreaseHealth(1);
				anim.SetBool("isAttacking", true);
			}
			else if (col.gameObject.GetComponent<FlyingEyeHealth>().currentHealth <= 0)
			{
			}
			else
			{

				StartCoroutine(Hurt(1, 0.5f));
			}
		}

	}

	IEnumerator Hurt(float _damage, float _time)
	{
		isHurting = true;
		rb.velocity = Vector2.zero;

		if (facingRight)
			rb.AddForce(new Vector2(-100f, 100f));
		else
			rb.AddForce(new Vector2(100f, 100f));

		
		anim.SetTrigger("isHurting");
		PlaySound(sounds[3]);
		healthComponent.DecreaseHealth(_damage);
		isHurting = false;
		yield return new WaitForSeconds(_time);
	}

	public void Load_GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}

}
