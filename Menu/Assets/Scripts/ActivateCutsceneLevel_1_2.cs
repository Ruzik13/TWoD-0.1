using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCutsceneLevel_1_2 : MonoBehaviour
{
	public GameObject Player;
	public GameObject Camera;
	[SerializeField] HumanHealth healthComponent;
	float hp;
	public GameObject CutScene;
	

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Player.GetComponent<Human>().enabled = false;
			PlayerPrefs.SetFloat("Health", healthComponent.currentHealth);
			Camera.GetComponent<CameraController>().enabled = false;
			CutScene.SetActive(true);
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

