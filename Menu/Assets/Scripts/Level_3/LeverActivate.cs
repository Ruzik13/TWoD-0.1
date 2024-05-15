using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LeverActivate : MonoBehaviour
{
    public GameObject platform;

	private bool playerInTrigger = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			playerInTrigger = true;
		}
	}

	private void Update()
	{
		if (playerInTrigger && Input.GetKeyDown(KeyCode.X)) 
		{
			GetComponent<Animator>().enabled = true;
			platform.GetComponent<MovingPlatform>().start_platform = true;
		}
	}
}
