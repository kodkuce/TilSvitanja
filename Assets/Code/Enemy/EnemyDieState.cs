using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyStates
{
    SpriteRenderer spriteRenderer;
    Color color;

    float hideBodyTimer = 1f;
    float speed = 2f;

    public EnemyDieState( EnemyController ec )
    {
        enemyController = ec;
        spriteRenderer = enemyController.spriteRenderer;
        color = spriteRenderer.color;

        animator.SetTrigger("die");
    }

    public override void ProcessDamage(int dmg)
    {
        return; //ignore dmg cuz dead allready
    }

    public override void VUpdate()
    {
        hideBodyTimer += -Time.deltaTime;

        if( hideBodyTimer < 0 )
        {
            color = new Color( color.r+speed*Time.deltaTime, color.g+speed*Time.deltaTime, 
                                color.b+speed*Time.deltaTime, color.a - Time.deltaTime );
            spriteRenderer.color = color;
            
            if( color.a <= 0.01f )
            {
                enemyController.DestorySelf();
            }            
        }
    }
}
