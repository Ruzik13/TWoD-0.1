using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message1 : MonoBehaviour
{
	public GameObject getKeyDownX;
	public GameObject message;
	public bool message_was_activated = false;

	private bool playerInTrigger = false;
	private bool messageIsActive = false;

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


	void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.X) && messageIsActive == false)
		{
			message.SetActive(true);
			messageIsActive = true;
			message_was_activated = true;
		}
		else if (playerInTrigger && Input.GetKeyDown(KeyCode.X))
		{
			message.SetActive(false);
			messageIsActive = false;
		}

	}
}
