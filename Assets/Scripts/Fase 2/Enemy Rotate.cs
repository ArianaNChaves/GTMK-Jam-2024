using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private float timeToRotate = 4.0f;
    [SerializeField] private float howMuchRotate = 3.0f;

    private void Start()
    {
        StartCoroutine(RotateAround());
    }
    
    private IEnumerator RotateAround()
    {
        while (true) 
        {
            float elapsedTime = 0.0f;
            bool whereRotate = RandomBool();

            while (elapsedTime < RandomFloat())
            {
                if (whereRotate)
                {
                    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                    elapsedTime += Time.deltaTime; 
                }
                else
                {
                    transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
                    elapsedTime += Time.deltaTime;  
                }
                
                yield return null;
            }
            
            yield return new WaitForSeconds(timeToRotate);
        }
    }

    private bool RandomBool()
    {
        int number = Random.Range(1, 3);
        if (number%2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private float RandomFloat()
    {
        float number = Random.Range(3.0f, 8.0f);
        return number;
    }
    
    
    
    
}
