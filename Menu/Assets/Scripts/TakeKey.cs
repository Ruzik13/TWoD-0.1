using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TakeKey : MonoBehaviour
{
	public GameObject Player;
	public GameObject Key;
	public GameObject help_message;
	private bool player_on_platform = false;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player_on_platform = true;
			help_message.SetActive(true);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player_on_platform = false;
			help_message.SetActive(false);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.X) && player_on_platform)
		{
			Player.GetComponent<ActiveThought>().player_have_key = true;
			Key.SetActive(false);

		}
	}
}