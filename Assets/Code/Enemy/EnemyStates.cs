using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStates
{
    protected EnemyController enemyController;
    protected Animator animator;

    public virtual void VUpdate(){}
    public virtual void VFixedUpdate(){}
    public virtual void ProcessDamage( int dmg )
    {
        enemyController.SetState( new EnemyDieState( enemyController ) );
    } 
}
