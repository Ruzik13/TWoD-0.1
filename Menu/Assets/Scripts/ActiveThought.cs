using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveThought : MonoBehaviour
{
    public bool activate_thought_not_key = false;
    public bool activate_thought_have_key = false;
	public bool player_have_key = false;
    public bool player_have_lever = false;
    public GameObject thought_not_key;
    public GameObject thought_not_key_reverse;
    public GameObject help_message;
    public GameObject thought_have_key;
    public GameObject thought_have_key_reverse;
	// Update is called once per frame
	void Update()
    {
        if (activate_thought_not_key)
        {
            if (GetComponent<Transform>().localScale.x == 1)
            {
				thought_not_key_reverse.SetActive(false);
				thought_not_key.SetActive(true);
			}
            else
            {
				thought_not_key.SetActive(false);
				thought_not_key_reverse.SetActive(true);
			}
        }
        else if (activate_thought_have_key)
        {
			help_message.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
				player_have_lever = true;
			}
			if (player_have_lever)
			{
				if (GetComponent<Transform>().localScale.x == 1)
				{
					thought_have_key_reverse.SetActive(false);
					thought_have_key.SetActive(true);
				}
				else
				{
					thought_have_key.SetActive(false);
					thought_have_key_reverse.SetActive(true);
				}
			}
		}
        else
        {
			thought_not_key.SetActive(false);
            thought_not_key_reverse.SetActive(false);
			help_message.SetActive(false);
			thought_have_key.SetActive(false);
			thought_have_key_reverse.SetActive(false);
		}
    }
}
