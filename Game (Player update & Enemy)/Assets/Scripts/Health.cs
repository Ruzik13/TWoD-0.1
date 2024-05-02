using UnityEngine;
using System.Collections;

public class RatHealth : MonoBehaviour
{
    [SerializeField] private int healthPoints;

    public void DecreaseHealth()
    {
        healthPoints--;
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

}