using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : Singleton<SpawnSystem>
{
    public GameObject npcEnemyThug;
    public GameObject npcEnemyCop;
    public GameObject npcRevolverShootParticle;
    public GameObject bloodSplater;






    private GameObject junkRoot;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.SpawnGameObject += OnSpawnGameObject;
        GameEvents.Instance.CleanUpSpawns += OnCleanUpSpawns;

        junkRoot = new GameObject("junkRoot");
    }


    void  OnApplicationQuit()
    {
        GameEvents.Instance.SpawnGameObject -= OnSpawnGameObject;
        GameEvents.Instance.CleanUpSpawns -= OnCleanUpSpawns;
    }

    private void OnCleanUpSpawns()
    {
        int childs = junkRoot.transform.childCount;
        for( int i = childs-1; i>0; i-- )
        {
            Destroy( junkRoot.transform.GetChild(i) );
        }
    }


    //TODO for stuff that spawns all time add pool
    private void OnSpawnGameObject(string what, Vector3 pos, Quaternion rot)
    {
        if (typeof(SpawnSystem).GetField(what) == null)
        {
            Debug.LogWarning("Missing gameobject for spawn named " + what);
        }
        else
        {
            GameObject spawnMe = null;

            //If have multiple gameobjects for same, pick random form list
            if (typeof(SpawnSystem).GetField(what).GetValue(this) is IList)
            {
                List<GameObject> gameObjectsToPickFrom = typeof(SpawnSystem).GetField(what).GetValue(this) as List<GameObject>;
                int r = UnityEngine.Random.Range(0, gameObjectsToPickFrom.Count);
                spawnMe = gameObjectsToPickFrom[r];
            }
            else
            {
                spawnMe = typeof(SpawnSystem).GetField(what).GetValue(this) as GameObject;
            }

            if( spawnMe != null )
            {
                Instantiate( spawnMe, pos, rot, junkRoot.transform );
            }
        }
    }

}
