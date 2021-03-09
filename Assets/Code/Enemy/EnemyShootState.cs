using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : EnemyStates
{
    float fireRate = 0.6f;
    public EnemyShootState( EnemyController ec)
    {
        base.enemyController = ec;
        if( ec.aimPreAttack )
        {
            enemyController.animator.SetTrigger("shoot");
        }
    }

    public override void VUpdate()
    {
        fireRate += -Time.deltaTime;
        if( fireRate < 0 )
        {
            fireRate = 2;
            Shoot();
        }
    }

    void Shoot()
    {
        enemyController.animator.SetTrigger("shoot");
        GameEvents.Instance.PlaySFX?.Invoke(enemyController.attackSound,0.8f);
        GameEvents.Instance.SpawnGameObject?.Invoke(enemyController.attackEffect, enemyController.gunMuzzle.position, Quaternion.identity );
        GameEvents.Instance.PlayerHit?.Invoke(1);
    }
}
