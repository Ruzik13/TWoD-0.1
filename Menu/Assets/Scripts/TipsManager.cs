using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    public static Action<string> displayTipEvent;
    public static Action disableTipEvent;

    [SerializeField] private TMP_Text messageText;

    private Animator anim;

    private int ActiveTips;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        displayTipEvent +=displayTip;
        disableTipEvent +=disableTip;
    }

    private void OnDisable()
    {
        displayTipEvent -= displayTip;
        disableTipEvent -= disableTip;
    }

    private void displayTip(string message)
    {
        messageText.text = message;
        anim.SetInteger("state", ++ActiveTips);
    }
    private void disableTip()
    {
        anim.SetInteger("state", --ActiveTips);
    }
}
