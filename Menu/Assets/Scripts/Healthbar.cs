using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
	[SerializeField] private HumanHealth healthComponent;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;

	private void Start()
	{
		healthComponent = GetComponent<HumanHealth>();
		totalhealthBar.fillAmount = healthComponent.GetHealthPoints() / 10;
	}
	private void Update()
	{
		currenthealthBar.fillAmount = healthComponent.GetHealthPoints() / 10;
	}
}