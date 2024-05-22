using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFall : MonoBehaviour
{
	[SerializeField] private HumanHealth healthComponent;
	[SerializeField] private RatHealth ratHealthComponent;
	[SerializeField] private Rat rat;
	[SerializeField] private SkeletonHealth skeletonhealthComponent;
	[SerializeField] private Skeleton skeleton;

	float hp = 0;
	float hp_rat = 0;
	float hp_skeleton = 0;
	bool new_trigger = false;

	private void Awake()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<HumanHealth>();
		}
		if(!ratHealthComponent)
		{
			ratHealthComponent = gameObject.AddComponent<RatHealth>();
		}

		healthComponent.Awake();
		ratHealthComponent.Awake();
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
				if (SceneManager.GetActiveScene().buildIndex == 2)
				{
					hp = healthComponent.currentHealth - 1;
					hp_rat = ratHealthComponent.currentHealth;
					PlayerPrefs.SetFloat("HP", hp);
					PlayerPrefs.SetFloat("HPrat", hp_rat);
				}
				
				else if (SceneManager.GetActiveScene().buildIndex == 3)
				{
					hp = healthComponent.currentHealth - 1;
					hp_skeleton = skeletonhealthComponent.currentHealth;
					PlayerPrefs.SetFloat("HP", hp);
					PlayerPrefs.SetFloat("HPskeleton", hp_skeleton);
				}

				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

		}

	}

	private void OnEnable()
	{
		if (PlayerPrefs.HasKey("HP") && PlayerPrefs.HasKey("HPrat"))
		{
			hp = PlayerPrefs.GetFloat("HP");
			hp_rat = PlayerPrefs.GetFloat("HPrat");
			healthComponent.currentHealth = hp;
			ratHealthComponent.currentHealth = hp_rat;
			if (hp_rat == 0f)
				rat.Calldead();
				
		}

		else if (PlayerPrefs.HasKey("HP") && PlayerPrefs.HasKey("HPskeleton"))
		{
			hp = PlayerPrefs.GetFloat("HP");
			hp_skeleton = PlayerPrefs.GetFloat("HPskeleton");
			healthComponent.currentHealth = hp;
			skeletonhealthComponent.currentHealth = hp_skeleton;
			if (hp_skeleton == 0f)
				skeleton.Calldead();

		}
		else
		{
			healthComponent.Awake();
			if (SceneManager.GetActiveScene().buildIndex == 2)
				ratHealthComponent.Awake();
			else if (SceneManager.GetActiveScene().buildIndex == 3)
				skeletonhealthComponent.Awake();
		}

		// Удаляем ключ "HP" после его использования
		PlayerPrefs.DeleteKey("HP");
		PlayerPrefs.DeleteKey("HPrat");
		PlayerPrefs.DeleteKey("HPskeleton");


	}
}
