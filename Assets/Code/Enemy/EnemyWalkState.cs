using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyStates
{
    float walkTime = 1.6f;

    public EnemyWalkState( EnemyController ec )
    {
        enemyController = ec;
        enemyController.animator.SetTrigger("walk");
    }

    public override void VUpdate()
    {
        walkTime += -Time.deltaTime;
        if( walkTime < 0 )
        {
            enemyController.SetState(new EnemyIdleState(enemyController) );
        }
    }
}
