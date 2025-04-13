using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActivateCutScene : MonoBehaviour
{
	public GameObject message;
	public GameObject cutScene;

	private bool player_on_trigger = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Human" && message.GetComponent<Message1>().message_was_activated && player_on_trigger == false)
		{
			player_on_trigger = true;
			collision.GetComponent<Human>().enabled = false;
			cutScene.SetActive(true);
		}
	}
}
