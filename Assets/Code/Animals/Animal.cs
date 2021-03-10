using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour, IEatDamage
{
    public void ReciveDamage(int dmg, Vector3 at)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<Animator>().SetTrigger("die");
        GameEvents.Instance.SpawnGameObject( "npcBloodParticle", at, Quaternion.identity );

        //Game diffrent endings
        PlayerPrefs.SetInt("goodend",1);
    }
}
