using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float reductionRate = 0.2f;
    [SerializeField] private float expandRate = 0.2f;
    [SerializeField] private float maxRate = 7.0f;
    [SerializeField] private float minRate = 2.0f;

    private void Start()
    {
        EnemyMouth.OnHit += MouthHit;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit Out!");
            transform.localScale += new Vector3(transform.localScale.x * expandRate, transform.localScale.y * expandRate, transform.localScale.z * expandRate);
            if (transform.localScale.x >= maxRate)
            {
                Debug.Log("Perdiste");
            }
        }
    }
    private void MouthHit()
    {
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (transform.localScale.x <= minRate)
        {
            Debug.Log("Ganaste");
        }
    }
}
