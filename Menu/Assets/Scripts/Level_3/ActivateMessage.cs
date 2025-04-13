using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMessage : MonoBehaviour
{
    public GameObject message;
	public GameObject getKeyDownX;

	private bool player_on_trigger = false;
	private bool message_is_active = false;

	void Update()
    {
        if (player_on_trigger && Input.GetKeyDown(KeyCode.X) && message_is_active == false)
		{
			message.SetActive(true);
			message_is_active = true;
		}
		else if (message_is_active && Input.GetKeyDown(KeyCode.X))
		{
			message.SetActive(false);
			message_is_active = false;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			player_on_trigger = true;
			getKeyDownX.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			player_on_trigger = false;
			getKeyDownX.SetActive(false);
		}
	}
}
