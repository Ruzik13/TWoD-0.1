using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		PlayerPrefs.DeleteKey("3level");
		PlayerPrefs.DeleteKey("2level");
	}

	public void ContinueGame()
	{
		if (PlayerPrefs.HasKey("3level"))
			SceneManager.LoadScene("Final");
		else if (PlayerPrefs.HasKey("2level"))
			SceneManager.LoadScene("Caves");
		else
			SceneManager.LoadScene("Ruzill_project");

	}

	public void ExitGame()
	{
		Debug.Log("Игра закрылась");
		Application.Quit();
	}
}
