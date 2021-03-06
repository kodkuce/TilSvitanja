using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEatDamage
{

    EnemyStates lastState;
    EnemyStates currentState;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform gunMuzzle;

    public void ReciveDamage(int dmg)
    {
        currentState.ProcessDamage(dmg);
    }

    public void SetState(EnemyStates ec)
    {
        lastState = currentState;
        currentState = ec;
        // Debug.Log( currentState );
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        currentState = new EnemyInvurnableState(this);
    }

    void Update()
    {
        currentState.VUpdate();
    }
}
