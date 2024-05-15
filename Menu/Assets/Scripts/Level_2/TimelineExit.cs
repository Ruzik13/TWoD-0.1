using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineExit : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
