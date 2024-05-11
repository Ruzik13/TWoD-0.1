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

	public void DecreaseHealth()
	{
		currentHealth -= 1;
	}

	
}