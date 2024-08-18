using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouth : MonoBehaviour
{
    public delegate void EnemyMouthAction();
    public static event EnemyMouthAction OnHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            OnHit?.Invoke();
        }
    }
}
