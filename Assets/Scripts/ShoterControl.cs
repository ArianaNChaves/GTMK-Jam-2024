using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterControl : MonoBehaviour
{
    [Header("Pool")]
    public GameObject BulletPrefab;
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
            GameObject Bullet = Instantiate(BulletPrefab, Spawns[randNum].position, Quaternion.identity);

            currentTime = maxTime;
        }
    }

}
