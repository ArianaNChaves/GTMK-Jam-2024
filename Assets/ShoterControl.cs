using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterControl : MonoBehaviour
{
    [Header("Pool")]
    
    [SerializeField] private Pool pool;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;

    [Header("Gun")]
    [SerializeField] private Transform[] Spawns;

    private void Start()
    {
        currentTime = maxTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            int randNum = Random.Range(0, Spawns.Length);
            GameObject Bullet = pool.GetBullet();

            if (Bullet != null)
            {
                Bullet.transform.position = Spawns[randNum].position;
                Bullet.SetActive(true);
            }
            currentTime = maxTime;
        }
    }

}
