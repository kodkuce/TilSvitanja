using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public GameObject nextLevel;
    public GameObject mainMenuLevel;

    void Start()
    {
        GameEvents.Instance.PlayerDied += OnPlayerDied;
        VStart();
    }

    protected virtual void VStart(){}
    private void OnPlayerDied()
    {
        StopAllCoroutines();
        GameEvents.Instance.DisplayTrasactionScreen("Game Ower");
        GameEvents.Instance.FightEnd?.Invoke();
        Invoke("GoMainMenu", 2f );
    }

    void GoMainMenu()
    {
        Destroy(gameObject);
        GameEvents.Instance.CleanUpSpawns?.Invoke();
        Instantiate( mainMenuLevel );
    }

    protected void GoNextLevel()
    {
        GameEvents.Instance.DisplayTrasactionScreen(nextLevel.name);
        Invoke( "DelayNextLevel", 2f );
    }
    void DelayNextLevel()
    {
        Destroy( gameObject );
        GameEvents.Instance.CleanUpSpawns?.Invoke();
        Instantiate( nextLevel );
    }

    void OnDestroy()
    {
        GameEvents.Instance.PlayerDied -= OnPlayerDied;
        VOnDestory();
    }

    protected virtual void VOnDestory(){}
    
    

}
