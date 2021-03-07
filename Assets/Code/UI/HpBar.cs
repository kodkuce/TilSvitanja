// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    int hp = 10;
    public Image hpfill;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.playerHit += OnPlayerHit;
    }

    void OnApplicationQuit()
    {
        GameEvents.Instance.playerHit -= OnPlayerHit;
    }

    private void OnPlayerHit(int dmg)
    {
        hp = hp - dmg;
        SpawnBlood();
        if( hp <= 0 )
        {
            Debug.Log("GAMEOWER");
        }
    }

    void SpawnBlood()
    {
        GameEvents.Instance.SpawnGameObject?.Invoke(
            "blood",
            new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-0.5f, 0.5f), -2),
            Quaternion.identity
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
