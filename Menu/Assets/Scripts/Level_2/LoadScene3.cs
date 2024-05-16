using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadScene3 : MonoBehaviour
{
    public GameObject mainCamera;
	[SerializeField] HumanHealth healthComponent;
	float hp;
	void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            mainCamera.GetComponent<CameraController>().enabled = true;
			PlayerPrefs.SetString("3level", "Loaded");
			PlayerPrefs.SetFloat("Health", healthComponent.currentHealth);
			PlayerPrefs.SetString("NewLevel", "Loaded");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
