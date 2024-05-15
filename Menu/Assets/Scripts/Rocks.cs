using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Sounds
{
	[SerializeField] private HumanHealth healthComponent;
	[SerializeField] private Animator anim;
	private GameObject myObject;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name.StartsWith("Falling"))
		{
			healthComponent.DecreaseHealth(1);
			anim.SetTrigger("isHurting");
			PlaySound(sounds[3]);

		}

		if (collision.gameObject.name.Equals("RockTrigger"))
			myObject = GameObject.Find("Falling");

		else if (collision.gameObject.name.Equals("RockTrigger (1)"))
			myObject = GameObject.Find("Falling (1)");
		else if (collision.gameObject.name.Equals("RockTrigger (2)"))
			myObject = GameObject.Find("Falling (2)");
		else if (collision.gameObject.name.Equals("RockTrigger (3)"))
			myObject = GameObject.Find("Falling (3)");
		else if (collision.gameObject.name.Equals("RockTrigger (4)"))
			myObject = GameObject.Find("Falling (4)");
		else if (collision.gameObject.name.Equals("RockTrigger (5)"))
			myObject = GameObject.Find("Falling (5)");
		else if (collision.gameObject.name.Equals("RockTrigger (6)"))
			myObject = GameObject.Find("Falling (6)");
		else if (collision.gameObject.name.Equals("RockTrigger (7)"))
			myObject = GameObject.Find("Falling (7)");
		else if (collision.gameObject.name.Equals("RockTrigger (8)"))
			myObject = GameObject.Find("Falling (8)");
		else if (collision.gameObject.name.Equals("RockTrigger (9)"))
			myObject = GameObject.Find("Falling (9)");
		else if (collision.gameObject.name.Equals("RockTrigger (10)"))
			myObject = GameObject.Find("Falling (11)");
		else if (collision.gameObject.name.Equals("RockTrigger (11)"))
			myObject = GameObject.Find("Falling (11)");
		else if (collision.gameObject.name.Equals("RockTrigger (12)"))
			myObject = GameObject.Find("Falling (12)");
		else if (collision.gameObject.name.Equals("RockTrigger (13)"))
			myObject = GameObject.Find("Falling (13)");
		else if (collision.gameObject.name.Equals("RockTrigger (14)"))
			myObject = GameObject.Find("Falling (14)");

		// Проверяем, что объект найден
		if (myObject != null)
		{
			// Получаем компонент Rigidbody2D
			Rigidbody2D rb = myObject.GetComponent<Rigidbody2D>();

			// Проверяем, что компонент найден
			if (rb != null)
			{
				rb.isKinematic = false;
			}
		}

		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
			

	}
}
