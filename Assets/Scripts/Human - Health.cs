using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanHealth : MonoBehaviour
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