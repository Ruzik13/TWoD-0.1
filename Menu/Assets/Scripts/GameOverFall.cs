using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFall : MonoBehaviour
{
	[SerializeField] private HumanHealth healthComponent;
	float hp = 0;
	bool new_trigger = false;
	private void Awake()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<HumanHealth>();
		}

		healthComponent.Awake();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name.Equals("Human"))
		{
			if (healthComponent.currentHealth < 1.5f)
			{
				healthComponent.DecreaseHealth(1);
				SceneManager.LoadScene("GameOver");
			}
				
			else
			{
				hp = healthComponent.currentHealth - 1;
				PlayerPrefs.SetFloat("HP", hp);
				SceneManager.LoadScene("Ruzill_project");
			}

		}

	}

	private void OnEnable()
	{
		if (PlayerPrefs.HasKey("HP"))
		{
			hp = PlayerPrefs.GetFloat("HP");
			healthComponent.currentHealth = hp;
		}
		else
		{
			healthComponent.Awake();
		}

		// Удаляем ключ "HP" после его использования
		PlayerPrefs.DeleteKey("HP");


	}
}
