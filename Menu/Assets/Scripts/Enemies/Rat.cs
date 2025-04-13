using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rat : Sounds
{
    Rigidbody2D rb;
	CircleCollider2D circle;
    BoxCollider2D box;
    [SerializeField] Animator anim;	
    RatHealth healthComponent;
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
		circle = GetComponent<CircleCollider2D>();
		box = GetComponent<BoxCollider2D>();
		// anim = GetComponent<Animator>();
        localScale = transform.localScale;
        enemyPatrol = GetComponentInParent<EnemyPatrol>();  
        healthComponent = GetComponent<RatHealth>();
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

            }

            else
            {
                anim.SetTrigger("isAttacking"); // Memainkan animasi terluka
                StartCoroutine(Hurt(col));
            }
        }
    }

    public void Calldead()
    {
        StartCoroutine(Enemydead());
    }

	public IEnumerator Enemydead()
	{
		dirX = 0;
		isDead = true;
		anim.SetTrigger("isDead"); // Memainkan animasi kematian
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
		rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
		circle.enabled = false;
		box.enabled = false;
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

        yield return new WaitForSeconds(2f);

        isHurting = false;
        enemyPatrol.Awake();

        HumanHealth humanHealth = col.gameObject.GetComponent<HumanHealth>();
        if (humanHealth != null && humanHealth.currentHealth <= 0)
        {
            anim.SetBool("isRunning", false);
            enemyPatrol.notmove();
        }
    }
}