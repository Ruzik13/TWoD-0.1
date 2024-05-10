using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanHealth : MonoBehaviour
{
    public int healthPoints = 3;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
			DecreaseHealth();

	}
	public void DecreaseHealth()
    {
        healthPoints--;
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

}