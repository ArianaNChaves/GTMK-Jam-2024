using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private  BulletDataSO bulletData;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate = 1.0f;

    private GameObject _bullet;
    private Bullet _bulletScript;
    private bool _canFire;
    private float _fireRateTime;

    private void Start()
    {
        _canFire = true;
        _fireRateTime = fireRate;
    }
    void Update()
    {
        _fireRateTime += Time.deltaTime;
        LookAtEnemy();
        if (CanAttack())
        {
            Attack(); 
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canFire)
        {
            _fireRateTime = 0;
            _bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            _bulletScript = _bullet.GetComponent<Bullet>();
            _bulletScript.Initiate(enemyPosition);
            PlayerScale.OnHitPlayer.Invoke();
            
            if (bulletData.currentBullets <= 0)
            {
                _canFire = false;
            }
        }
    }
    private void LookAtEnemy()
    {
        Vector3 direction = enemyPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    private bool CanAttack()
    {
        if (_fireRateTime >= fireRate )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
