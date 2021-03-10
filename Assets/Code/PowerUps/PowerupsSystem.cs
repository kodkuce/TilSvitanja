using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsSystem : MonoBehaviour
{
    List<GameObject> powerups;
    Vector3 outOfScreen = new Vector3(-50,0,0);
    void Start()
    {
        GameEvents.Instance.FightStart += OnFightStart;
        GameEvents.Instance.FightEnd += OnFightEnd;

        powerups = new List<GameObject>();
        for( int i=0; i<transform.childCount; i++ )
        {
            powerups.Add( transform.GetChild(i).gameObject );
        }
    }

    private void OnFightStart()
    {
        StartCoroutine("PowerupsSpawn");
    }

    private void OnFightEnd()
    {
        StopAllCoroutines();
        RemovePowerups();
    }

    void RemovePowerups()
    {
        foreach( GameObject g in powerups )
        {
            g.transform.position = outOfScreen;
        }
    }

    IEnumerator PowerupsSpawn()
    {
        yield return new WaitForSeconds( 3f );

        while(true)
        {
            yield return new WaitForSeconds( Random.Range(3f,7f) );
            //pick random powerup
            GameObject pow = powerups[Random.Range(0, powerups.Count)];
            pow.transform.position = new Vector3( Random.Range(-2.5f, 2.5f), Random.Range(-1f, -1.6f), -9 );

            yield return new WaitForSeconds( 5f );
            RemovePowerups();
        }
    }
}
