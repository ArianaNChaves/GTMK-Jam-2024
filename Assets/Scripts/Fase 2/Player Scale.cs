using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public static Action OnHitPlayer;
    
    [SerializeField] private float reductionRate = 0.05f;
    [SerializeField] private float minRate = 0.05f;


    private void OnEnable()
    {
        OnHitPlayer += ReduceScale;
    }
    private void OnDisable()
    {
        OnHitPlayer -= ReduceScale;
    }

    private void ReduceScale()
    {
        Debug.Log("Se llamo evento");
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (transform.localScale.x <= minRate)
        {
            Debug.Log("Chiquito, volver a juntar balas");
        }
    }
}
