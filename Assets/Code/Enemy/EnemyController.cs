using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEatDamage
{
    EnemyStates currentState;
    public int hp = 1;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform gunMuzzle;
    public bool aimPreAttack;
    public string attackSound;
    public string attackEffect;

    public void ReciveDamage(int dmg, Vector3 at)
    {
        currentState.ProcessDamage(dmg, at);
    }

    public void SetState(EnemyStates ec)
    {
        currentState = ec;
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
