using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStates
{
    protected EnemyController enemyController;

    public virtual void VUpdate(){}
    public virtual void ProcessDamage( int dmg )
    {
        enemyController.hp += -dmg;
        if( enemyController.hp <= 0)
        {
            enemyController.SetState( new EnemyDieState( enemyController ) );
        }
    }
}
