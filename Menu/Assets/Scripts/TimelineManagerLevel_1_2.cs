using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManagerLevel_1_2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            Player.GetComponent<Human>().enabled = true;
            Camera.GetComponent<CameraController>().enabled = true;
        }
    }
}
