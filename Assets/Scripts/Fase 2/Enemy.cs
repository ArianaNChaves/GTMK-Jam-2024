using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float reductionRate = 0.2f;
    [SerializeField] private float expandRate = 0.2f;
    [SerializeField] private float maxScaleRate = 7.0f;
    [SerializeField] private float minScaleRate = 2.0f;

    private void OnEnable()
    {
        EnemyMouth.OnHit += MouthHit;
    }

    private void OnDisable()
    {
        EnemyMouth.OnHit -= MouthHit;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit Out!");
            transform.localScale += new Vector3(transform.localScale.x * expandRate, transform.localScale.y * expandRate, transform.localScale.z * expandRate);
            if (transform.localScale.x >= maxScaleRate)
            {
                Debug.Log("Perdiste");
            }
        }
    }
    private void MouthHit()
    {
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (transform.localScale.x <= minScaleRate)
        {
            Debug.Log("Ganaste");
        }
    }
}
