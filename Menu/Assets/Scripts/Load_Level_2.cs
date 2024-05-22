using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level_2 : MonoBehaviour
{
	public GameObject panel;
	public GameObject Timeline;
	public GameObject mainCamera;
	float hp;
	[SerializeField] HumanHealth healthComponent;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			panel.SetActive(true);
			collision.gameObject.GetComponent<Human>().enabled = false;
			PlayerPrefs.SetString("NewLevel", "Loaded");
			mainCamera.GetComponent<CameraController>().enabled = false;
			Timeline.SetActive(true);
		}
	}

	private void OnEnable()
	{
		if (PlayerPrefs.HasKey("Health"))
		{
			hp = PlayerPrefs.GetFloat("Health");
			healthComponent.currentHealth = hp;
		}

		else
			healthComponent.Awake();

		// PlayerPrefs.DeleteKey("Health");
	}
}

