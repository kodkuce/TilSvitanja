using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : Singleton<SpawnSystem>
{
    public GameObject npcEnemyThugBoss;
    public GameObject npcEnemyThug;
    public GameObject npcEnemyCop;
    public GameObject npcEnemyFam;
    public GameObject npcRevolverShootParticle;
    public GameObject npcAxeSwingParticle;
    public GameObject npcBloodParticle;
    public GameObject bloodSplater;
    public GameObject powerupBOOMEffect;





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
        for( int i = childs-1; i>=0; i-- )
        {
            Destroy( junkRoot.transform.GetChild(i).gameObject );
        }
    }


    //TODO for stuff that spawns a lot implement some pool if have time
    private void OnSpawnGameObject(string what, Vector3 pos, Quaternion rot)
    {
        if (typeof(SpawnSystem).GetField(what) == null)
        {
            Debug.LogWarning("Missing gameobject for spawn named " + what);
        }
        else
        {
            // Debug.Log("Should spawn "+ what );
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
