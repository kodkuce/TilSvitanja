using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public Action<string, float> PlaySFX;
    public Action<string, Vector3, Quaternion> SpawnGameObject;
}
