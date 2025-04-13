using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour
{
	public GameObject timeLine;
	public GameObject cameraController;
	[SerializeField] HumanHealth healthComponent;
	float hp;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			cameraController.GetComponent<CameraController>().enabled = false;
			PlayerPrefs.SetFloat("Health", healthComponent.currentHealth);
			PlayerPrefs.SetString("NewLevel", "Loaded");
			timeLine.SetActive(true);
		}
	}
}
