using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtActivate : MonoBehaviour
{
	public GameObject thought1;
	public GameObject thought2;
	public GameObject thought3;
	public GameObject thought4;
	public GameObject thought5;
	public GameObject thought6;

	private List<bool> active_thoughts = new List<bool>() { false, false, false, false, false, false };
	private bool go_left = false;
	private bool go_right = false;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "TriggerThought1" && active_thoughts[0] == false)
		{
			thought1.SetActive(true);
			active_thoughts[0] = true;
		}
		if (collision.gameObject.name == "TriggerThought2" && active_thoughts[1] == false)
		{
			thought2.SetActive(true);
			active_thoughts[1] = true;
		}
		if (collision.gameObject.name == "TriggerThought3" && active_thoughts[2] == false)
		{
			thought3.SetActive(true);
			active_thoughts[2] = true;
		}
		if (collision.gameObject.name == "TriggerThought4" && active_thoughts[3] == false)
		{
			thought4.SetActive(true);
			active_thoughts[3] = true;
		}
		if (collision.gameObject.name == "TriggerThought5" && active_thoughts[4] == false)
		{
			thought5.SetActive(true);
			active_thoughts[4] = true;
		}
		if (collision.gameObject.name == "TriggerThought6" && active_thoughts[5] == false)
		{
			thought6.SetActive(true);
			active_thoughts[5] = true;
		}
	}
	
	private void Update() 
	{
		if (GetComponent<Transform>().localScale.x == -1)
		{
			go_left = true;
			go_right = false;
		}
		else
		{
			go_right = true;
			go_left = false;
		}
		if (go_left)
		{
			thought1.GetComponent<Transform>().localScale = new Vector3(-1, thought1.GetComponent<Transform>().localScale.y, thought1.GetComponent<Transform>().localScale.z);
			thought2.GetComponent<Transform>().localScale = new Vector3(-1, thought2.GetComponent<Transform>().localScale.y, thought2.GetComponent<Transform>().localScale.z);
			thought3.GetComponent<Transform>().localScale = new Vector3(-1, thought3.GetComponent<Transform>().localScale.y, thought3.GetComponent<Transform>().localScale.z);
			thought4.GetComponent<Transform>().localScale = new Vector3(-1, thought4.GetComponent<Transform>().localScale.y, thought4.GetComponent<Transform>().localScale.z);
			thought5.GetComponent<Transform>().localScale = new Vector3(-1, thought5.GetComponent<Transform>().localScale.y, thought5.GetComponent<Transform>().localScale.z);
			thought6.GetComponent<Transform>().localScale = new Vector3(-1, thought6.GetComponent<Transform>().localScale.y, thought6.GetComponent<Transform>().localScale.z);

		}
		if (go_right)
		{
			thought1.GetComponent<Transform>().localScale = new Vector3(1, thought1.GetComponent<Transform>().localScale.y, thought1.GetComponent<Transform>().localScale.z);
			thought2.GetComponent<Transform>().localScale = new Vector3(1, thought2.GetComponent<Transform>().localScale.y, thought2.GetComponent<Transform>().localScale.z);
			thought3.GetComponent<Transform>().localScale = new Vector3(1, thought3.GetComponent<Transform>().localScale.y, thought3.GetComponent<Transform>().localScale.z);
			thought4.GetComponent<Transform>().localScale = new Vector3(1, thought4.GetComponent<Transform>().localScale.y, thought4.GetComponent<Transform>().localScale.z);
			thought5.GetComponent<Transform>().localScale = new Vector3(1, thought5.GetComponent<Transform>().localScale.y, thought5.GetComponent<Transform>().localScale.z);
			thought6.GetComponent<Transform>().localScale = new Vector3(1, thought6.GetComponent<Transform>().localScale.y, thought6.GetComponent<Transform>().localScale.z);
		}
	}
}
