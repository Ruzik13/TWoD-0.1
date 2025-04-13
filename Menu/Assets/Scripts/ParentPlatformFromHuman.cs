using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatformFromHuman : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("MoveingPlatform"))
		{
			this.transform.parent = collision.transform;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("MoveingPlatform"))
		{
			this.transform.parent = null;
		}
	}

}
