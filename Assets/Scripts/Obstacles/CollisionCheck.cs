using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private bool _waitImpact;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !_waitImpact)
        {
            _waitImpact = true;
            PlayerScale.OnHitPlayer.Invoke();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && _waitImpact)
        {
            _waitImpact = false;
        }
    }
}
