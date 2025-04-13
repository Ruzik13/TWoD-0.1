using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    private Transform back_Transform;
    private float back_Size;
    private float back_pos;
	void Start()
	{
		back_Transform = GetComponent<Transform>();
        back_Size = GetComponent<SpriteRenderer>().bounds.size.x;
		print(back_Size);
	}
	void Update()
	{
		speed = 180;
		Move();
	}
	public void Move()
	{
		back_pos -= speed * Time.deltaTime;
		print(back_pos);
		if (back_pos < -5626)
			back_pos = back_Size;

		//back_pos = Mathf.Repeat(back_pos, back_Size);
		if (back_pos == -back_Size*4)
			back_pos = 0;
		back_Transform.position = new Vector3(back_pos, 0, 0);

	}
}
