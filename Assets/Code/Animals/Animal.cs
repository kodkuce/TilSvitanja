using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour, IEatDamage
{
    public void ReciveDamage(int dmg)
    {
        GetComponentInChildren<Animator>().SetTrigger("die");

        //Game diffrent endings
        PlayerPrefs.SetInt("goodend",1);
    }
}
