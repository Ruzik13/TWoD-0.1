using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunduk_trigger : MonoBehaviour
{
    public GameObject Player;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (Player.GetComponent<ActiveThought>().player_have_key)
				Player.GetComponent<ActiveThought>().activate_thought_have_key = true;
			else
			{
				Player.GetComponent<ActiveThought>().activate_thought_not_key = true;
			}
				
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.GetComponent<ActiveThought>().activate_thought_not_key = false;
			Player.GetComponent<ActiveThought>().activate_thought_have_key = false;
		}
	}
}
