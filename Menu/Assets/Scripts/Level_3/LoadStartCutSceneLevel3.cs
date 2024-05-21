using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LoadStartCutSceneLevel3 : MonoBehaviour
{
    public GameObject startCutScene;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            startCutScene.SetActive(true);
        }
    }
}
