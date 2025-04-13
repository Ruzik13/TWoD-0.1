using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ExitTimeline : MonoBehaviour
{
    public GameObject panel;
    
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            panel.SetActive(false);
        }

    }
}
