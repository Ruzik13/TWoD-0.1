using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLever : MonoBehaviour
{
	public GameObject Player;
	public GameObject help_message;
	public GameObject lever;
	public GameObject platform;

	private bool player_on_platform = false;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && Player.GetComponent<ActiveThought>().player_have_lever)
		{
			help_message.SetActive(true);
			player_on_platform = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			help_message.SetActive(false);
			player_on_platform = false;
		}
	}

	private void Update()
    {
        if (player_on_platform)
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				lever.SetActive(true);
				platform.GetComponent<MovingPlatform_Level1>().start_platform = true;
			}
		}
    }
}
