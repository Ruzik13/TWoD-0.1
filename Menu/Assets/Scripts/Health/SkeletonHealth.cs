using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHealth : MonoBehaviour
{
	[SerializeField] private float startingHealth;
	public float currentHealth;
	Animator anim;

	public void Awake()
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
