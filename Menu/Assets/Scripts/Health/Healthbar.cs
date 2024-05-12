using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour
{
	[SerializeField] private HumanHealth healthComponent;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;

	private void Start()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<HumanHealth>();
		}
		totalhealthBar.fillAmount = healthComponent.currentHealth / 10;
	}
	private void Update()
	{
		currenthealthBar.fillAmount = healthComponent.currentHealth / 10;
	}
}