using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public float speed = 3f;
	public bool start_platform = false;

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
			if (pos.y < start_pos.y + 3f)
			{
				transform.position = new Vector2(pos.x, pos.y + speed * Time.deltaTime);
			}
			else
			{
				platform_is_started = true;
			}
		}
	}

}
