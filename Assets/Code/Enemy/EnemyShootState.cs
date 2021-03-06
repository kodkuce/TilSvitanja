using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : EnemyStates
{
    float fireRate = 1f;
    public EnemyShootState( EnemyController ec)
    {
        base.enemyController = ec;
        enemyController.animator.SetTrigger("shoot");
    }

    public override void VUpdate()
    {
        fireRate += -Time.deltaTime;
        if( fireRate < 0 )
        {
            fireRate = 1;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("SHOOT");
    }
}
