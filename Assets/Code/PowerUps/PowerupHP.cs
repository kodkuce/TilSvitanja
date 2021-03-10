using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHP : MonoBehaviour, IEatDamage
{
    public void ReciveDamage(int dmg, Vector3 at)
    {
        GameEvents.Instance.PowerupHP?.Invoke();
        transform.position = Vector3.left * 50;
    }
}
