using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class load_next_scene : MonoBehaviour
{
	[SerializeField] private HumanHealth healthComponent;

	private void Awake()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<HumanHealth>();
		}

		healthComponent.Awake();
	}
	// Update is called once per frame


	void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused || Input.GetKey(KeyCode.K))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
