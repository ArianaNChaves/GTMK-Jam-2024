using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

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
        }
    }
    private void LookAtEnemy()
    {
        transform.up = enemyPosition.position - transform.position;
    }
}
