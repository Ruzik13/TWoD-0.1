using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMessage : MonoBehaviour
{
	public GameObject message;
	public GameObject help_message;
	private bool player_on_platform = false;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			help_message.SetActive(true);
			player_on_platform = true;
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player_on_platform = false;
			help_message.SetActive(false);
			message.SetActive(false);
		}
	}

	private void Update()
	{
		if (player_on_platform) 
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				message.SetActive(true);
			}
		}
	}
}
