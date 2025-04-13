using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
        Player.GetComponent<Human>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
			Player.GetComponent<Human>().enabled = true;
			GetComponent<TimelineScript>().enabled = false;
		}
	}
}
