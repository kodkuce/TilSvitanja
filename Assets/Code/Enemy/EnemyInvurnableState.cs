using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvurnableState : EnemyStates
{
    SpriteRenderer spriteRenderer;
    Color color;
    float speed = 2;

    public EnemyInvurnableState( EnemyController ec )
    {
        enemyController = ec;
        Start();
    }
    void Start()
    {
        spriteRenderer = enemyController.spriteRenderer;
        color = spriteRenderer.color;
    }

    void ColorBlackToWhite()
    {
        if( spriteRenderer.color != UnityEngine.Color.white )
        {
            color = new Color( color.r  + speed*Time.deltaTime, color.g + speed*Time.deltaTime , color.b + speed*Time.deltaTime );
            if( color.r >= 1 && color.g >=1 && color.b >=1 ) { color = Color.white; }
            spriteRenderer.color = color;
        }else{
            enemyController.SetState( new EnemyWalkState( enemyController ));
        }
    }
    public override void VUpdate()
    {
        ColorBlackToWhite();
    }
    public override void ProcessDamage(int dmg)
    {
        return; //just return cuz invurnable
    }
}
