using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2_Activate : MonoBehaviour
{
	public GameObject platform;
	public GameObject getKeyDownX;

	private bool playerInTrigger = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			playerInTrigger = true;
			getKeyDownX.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			playerInTrigger = false;
			getKeyDownX.SetActive(false);
		}
	}

	private void Update()
	{
		if (playerInTrigger && Input.GetKeyDown(KeyCode.X))
		{
			GetComponent<Animator>().enabled = true;
			platform.SetActive(true);
		}
	}

}
