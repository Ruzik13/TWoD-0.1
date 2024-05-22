using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadFinalCutScene : MonoBehaviour
{
	public GameObject panel;
	public GameObject cameraControl;
    public GameObject finalCutScene;
	// Update is called once per frame

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Human")
		{
			panel.SetActive(true);
			collision.GetComponent<Human>().enabled = false;
			cameraControl.GetComponent<CameraController>().enabled = false;
			finalCutScene.SetActive(true);
		}
	}
}
