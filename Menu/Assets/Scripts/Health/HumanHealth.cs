using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
	public float currentHealth;
	private void Awake()
	{
		currentHealth = startingHealth;
	}

	public void DecreaseHealth(float _damage)
	{
		currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
	}

	public void AddHealth(float _value)
	{
		currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
	}

	
}