// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    int hp = 10;
    bool gameEnded;
    public Image hpfill;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.PlayerHit += OnPlayerHit;
    }

    void OnApplicationQuit()
    {
        GameEvents.Instance.PlayerHit -= OnPlayerHit;
    }

    void OnEnable()
    {
        hp = 10;
        hpfill.fillAmount = 1;
        gameEnded = false;
    }

    private void OnPlayerHit(int dmg)
    {
        // Debug.Log("HITED");
        hp = hp - dmg;
        hpfill.fillAmount = hp/10.0f;
        SpawnBlood();
        if( hp <= 0  && !gameEnded )
        {
            gameEnded = true;
            GameEvents.Instance.PlayerDied?.Invoke();
        }
    }

    void SpawnBlood()
    {
        GameEvents.Instance.SpawnGameObject?.Invoke(
            "bloodSplater",
            new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-0.5f, 0.5f), -2),
            Quaternion.identity
        );
    }
}
