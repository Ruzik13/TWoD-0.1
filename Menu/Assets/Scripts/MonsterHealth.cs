using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    Animator anim; 

    public void DecreaseHealth()
    {
        anim = GetComponent<Animator>();
        healthPoints--;
        anim.SetTrigger("isHurting");
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

}