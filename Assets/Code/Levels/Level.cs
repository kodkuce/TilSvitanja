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
        Invoke("GoMainMenu", 2f );
    }

    void GoMainMenu()
    {
        Instantiate( mainMenuLevel );
        Destroy(gameObject);
    }

    protected void GoNextLevel()
    {
        GameEvents.Instance.DisplayTrasactionScreen(nextLevel.name);
        Invoke( "DelayNextLevel", 2f );
    }
    void DelayNextLevel()
    {
        Instantiate( nextLevel );
        Destroy( gameObject );
    }
    
    

}
