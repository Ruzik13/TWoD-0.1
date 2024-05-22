using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthbarFlyingEye : MonoBehaviour
{
	[SerializeField] private FlyingEyeHealth healthComponent;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;

	private void Start()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<FlyingEyeHealth>();
		}
		totalhealthBar.fillAmount = 5 / 10;
	}
	private void Update()
	{
		currenthealthBar.fillAmount = healthComponent.currentHealth / 10;
	}

}
