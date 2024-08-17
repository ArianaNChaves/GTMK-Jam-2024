using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float rotationSpeed;
    
    void Update()
    {
        RotateParent();
    }

    private void RotateParent()
    {
        transform.RotateAround(center.position, Vector3.forward, rotationSpeed * Time.deltaTime);

    }
}
