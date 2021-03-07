using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    void Start()
    {
        GameEvents.Instance.GameEnd += OnGameEnd;
        GameEvents.Instance.StartFight += OnStartFight;
    }

    private void OnStartFight()
    {
        ShowHud();
    }

    private void OnGameEnd(bool win)
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
