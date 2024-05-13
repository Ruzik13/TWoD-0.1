using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtActivate : MonoBehaviour
{
	public GameObject thought;

	private bool thought_is_active = false;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Trigger_for_thought" && thought_is_active == false)
		{
			thought.SetActive(true);
			thought_is_active = true;
		}
	}
}
