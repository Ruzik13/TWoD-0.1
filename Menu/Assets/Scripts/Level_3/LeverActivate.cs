using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LeverActivate : MonoBehaviour
{
    public GameObject platform;
	public GameObject getKeyDownX;

	private bool playerInTrigger = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			getKeyDownX.SetActive(true);
			playerInTrigger = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		getKeyDownX.SetActive(false);
		playerInTrigger = false;
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
