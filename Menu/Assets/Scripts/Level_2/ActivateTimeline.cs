using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour
{
	public GameObject timeLine;
	public GameObject cameraController;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			cameraController.GetComponent<CameraController>().enabled = false;
			timeLine.SetActive(true);
		}
	}
}
