using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaleObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private float maxThreshold = 8.5f;
    [SerializeField] private float minThreshold = 1.0f;
    
    private void Update()
    {
        ScaleObstacle();
    }

    private void ScaleObstacle()
    {
        float targetScaleY = Mathf.Lerp(minThreshold, maxThreshold, Mathf.PingPong(Time.time * speed, 1));
        float targetScaleX = Mathf.Lerp(minThreshold, maxThreshold, Mathf.PingPong(Time.time * speed, 1));
        transform.localScale = new Vector3(targetScaleX, targetScaleY, transform.localScale.z);
    }
}
