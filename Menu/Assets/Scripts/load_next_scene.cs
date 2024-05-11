using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class load_next_scene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
