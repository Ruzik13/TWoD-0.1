using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCutsceneLevel_1_2 : MonoBehaviour
{
	public GameObject Player;
	public GameObject Camera;
    public GameObject CutScene;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Player.GetComponent<Human>().enabled = false;
			Camera.GetComponent<CameraController>().enabled = false;
			CutScene.SetActive(true);
		}
	}
}
