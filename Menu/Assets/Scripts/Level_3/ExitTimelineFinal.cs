using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ExitTimelineFinal : MonoBehaviour
{
    public GameObject getKeyDownX;
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(0);
        }
        else if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            getKeyDownX.SetActive(true);
        }

	}
}
