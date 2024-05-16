using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineExit : MonoBehaviour
{
    [SerializeField] HumanHealth healthComponent;
	float hp;


	void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            PlayerPrefs.SetString("2level", "Loaded");
			PlayerPrefs.SetString("NewLevel", "Loaded");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

			if (PlayerPrefs.HasKey("Health"))
			{
				hp = PlayerPrefs.GetFloat("Health");
				healthComponent.currentHealth = hp;
			}

			else
				healthComponent.Awake();


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
