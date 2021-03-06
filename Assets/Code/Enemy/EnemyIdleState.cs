using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStates
{
    public EnemyIdleState( EnemyController ec )
    {
        enemyController = ec;
        enemyController.animator.SetTrigger("stop");
    }


    float idleTime = 1;
    public override void VUpdate()
    {
        idleTime += -Time.deltaTime;
        if( idleTime < 0 )
        {
            enemyController.SetState( new EnemyShootState( enemyController ));
        }
    }

}
