using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBOOM : MonoBehaviour, IEatDamage
{
    public void ReciveDamage(int dmg, Vector3 at)
    {
        GameEvents.Instance.SpawnGameObject("powerupBOOMEffect", new Vector3(0,0,-9), Quaternion.identity);

        EnemyController[] ecGroup = GameObject.Find("junkRoot")?.GetComponentsInChildren<EnemyController>();
        foreach( EnemyController ec in ecGroup )
        {
            ec.ReciveDamage(1, Vector3.left*50 );
        }

        transform.position = Vector3.left*50;
    }


}
