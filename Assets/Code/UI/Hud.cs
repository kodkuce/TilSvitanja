using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    void Start()
    {
        GameEvents.Instance.FightEnd += OnFightEnd;
        GameEvents.Instance.FightStart += OnFightStart;
    }

    private void OnFightStart()
    {
        ShowHud();
    }

    private void OnFightEnd()
    {
        HideHud();
    }

    void HideHud()
    {
        for(int i=0; i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void ShowHud()
    {
        for(int i=0; i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
