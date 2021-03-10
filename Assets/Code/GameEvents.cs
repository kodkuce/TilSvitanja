using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public Action<string, float> PlaySFX;

    public Action<string, Vector3, Quaternion> SpawnGameObject;
    public Action CleanUpSpawns;

    public Action FightStart;
    public Action FightEnd;
    public Action<int> PlayerHit;
    public Action PlayerShoot;
    public Action PlayerDied;
    public Action EnemyDied;


    public Action<DialogPart> DialogDisplay;
    public Action DialogClose;
    public Action<string> DisplayTrasactionScreen;
    public Action<string> DisplayNotification;

    //powerups
    public Action PowerupHP;
    public Action PowerupBOOM;
}
