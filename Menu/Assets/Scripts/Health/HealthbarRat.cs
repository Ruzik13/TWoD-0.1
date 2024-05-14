using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthbarRat : MonoBehaviour
{
	[SerializeField] private RatHealth healthComponent;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;

	private void Start()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<RatHealth>();
		}
		totalhealthBar.fillAmount = 3 / 10;
	}
	private void Update()
	{
		currenthealthBar.fillAmount = healthComponent.currentHealth / 10;
	}
}