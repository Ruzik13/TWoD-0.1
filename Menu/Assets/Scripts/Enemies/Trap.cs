using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
	[SerializeField] private float _damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name.Equals("Human"))
			collision.GetComponent<Human>().callHurt(1, 1.5f);
	}
}
