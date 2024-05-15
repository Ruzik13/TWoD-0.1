using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level_2 : MonoBehaviour
{
	public GameObject Timeline;
	public GameObject mainCamera;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Human>().enabled = false;
			mainCamera.GetComponent<CameraController>().enabled = false;
			Timeline.SetActive(true);
		}
	}
}
