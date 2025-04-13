using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ExitCutScene : MonoBehaviour
{
	public GameObject mainCamera;
	public GameObject Human;
	void Update()
	{
		if (GetComponent<PlayableDirector>().state == PlayState.Paused)
		{
			mainCamera.GetComponent<CameraController>().enabled = true;
			Human.GetComponent<Human>().enabled = true;
		}
	}

}
