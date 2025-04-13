using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform_Level1 : MonoBehaviour
{
    public float speed = 3f;
    public bool start_platform = false;

    private bool moving_left = false;
    private bool platform_is_started = false;
    private Vector2 start_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 pos = transform.position;

		if (start_platform && platform_is_started == false)
        {
            if (pos.y < start_pos.y+7f) 
            {
				transform.position = new Vector2(pos.x, pos.y + speed * Time.deltaTime);
			}
            else
            {
                platform_is_started = true;
            }
		}

        else if (platform_is_started)
        {
			if (pos.x < start_pos.x - 5f)
            {
                moving_left = false;
            }
            else if (pos.x > start_pos.x + 5f)
            {
                moving_left = true;
            }
            if (moving_left)
            {
                transform.position = new Vector2(pos.x - speed * Time.deltaTime, pos.y);
            }
            else
            {
                transform.position = new Vector2(pos.x + speed * Time.deltaTime, pos.y);
            }
        }
    }
}
