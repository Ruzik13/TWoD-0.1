using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthbarSkeleton : MonoBehaviour
{
	[SerializeField] private SkeletonHealth healthComponent;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;

	private void Start()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<SkeletonHealth>();
		}
		totalhealthBar.fillAmount = healthComponent.currentHealth / 10;
	}
	private void Update()
	{
		currenthealthBar.fillAmount = healthComponent.currentHealth / 10;
	}
}