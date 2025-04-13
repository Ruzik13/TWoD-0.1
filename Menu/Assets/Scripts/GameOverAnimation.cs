using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class GameOverAnimation : MonoBehaviour
{
    public GameObject GetKeyDown;
    private bool keyDownActive = false;
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            GetKeyDown.SetActive(true);
            keyDownActive = true;
        }
        if (keyDownActive && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
