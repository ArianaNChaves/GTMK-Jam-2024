using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float reductionRate = 0.05f;
    [SerializeField] private float minRate = 0.05f;

    private GameObject _bullet;
    private Bullet _bulletScript;
    void Update()
    {
        LookAtEnemy();
        Attack();
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            _bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            _bulletScript = _bullet.GetComponent<Bullet>();
            _bulletScript.Initiate(enemyPosition);

            ReduceScale();
        }
    }
    private void LookAtEnemy()
    {
        transform.up = enemyPosition.position - transform.position;
    }

    private void ReduceScale()
    {
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (transform.localScale.x <= minRate)
        {
            Debug.Log("Chiquito, volver a juntar balas");
        }
    }
}
