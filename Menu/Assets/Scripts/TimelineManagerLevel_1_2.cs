using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManagerLevel_1_2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
	float hp;
    [SerializeField] HumanHealth healthComponent;
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            Player.GetComponent<Human>().enabled = true;
			PlayerPrefs.SetFloat("Health", healthComponent.currentHealth);
			PlayerPrefs.SetString("NewLevel", "Loaded");
			Camera.GetComponent<CameraController>().enabled = true;
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

