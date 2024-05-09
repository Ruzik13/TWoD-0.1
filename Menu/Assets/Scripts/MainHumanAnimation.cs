using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHumanAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool IsMoving { private get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }
}
