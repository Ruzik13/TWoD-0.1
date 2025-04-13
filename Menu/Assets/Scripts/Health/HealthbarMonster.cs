using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthbarMonster : MonoBehaviour
{
	[SerializeField] private MonsterHealth healthComponent;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;

	private void Start()
	{
		if (!healthComponent)
		{
			healthComponent = gameObject.AddComponent<MonsterHealth>();
		}
		totalhealthBar.fillAmount = 5 / 10;
	}
	private void Update()
	{
		currenthealthBar.fillAmount = healthComponent.currentHealth / 10;
	}
}