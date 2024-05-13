using UnityEngine;
using System.Collections;

public class RatHealth : MonoBehaviour
{
	[SerializeField] private float startingHealth;
	public float currentHealth;
	Animator anim;

	private void Awake()
	{
		currentHealth = startingHealth;
	}

	public void DecreaseHealth(float _damage)
    {
        anim = GetComponent<Animator>();
		currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
		anim.SetTrigger("isHurting");
    }


}