using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStates
{
    protected EnemyController enemyController;

    public virtual void VUpdate(){}
    public virtual void ProcessDamage( int dmg, Vector3 at )
    {
        enemyController.hp += -dmg;
        GameEvents.Instance.SpawnGameObject( "npcBloodParticle", at, Quaternion.identity );


        if( enemyController.hp <= 0)
        {
            enemyController.SetState( new EnemyDieState( enemyController ) );
        }
    }
}
