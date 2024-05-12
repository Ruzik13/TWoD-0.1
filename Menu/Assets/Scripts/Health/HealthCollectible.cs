using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.name.Equals("Human"))
		{
			col.GetComponent<HumanHealth>().AddHealth(healthValue);
			gameObject.SetActive(false);
		}
	}
}
