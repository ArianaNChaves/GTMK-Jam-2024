using System;
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

    private void Start()
    {
        Cursor.visible = false;
    }

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
            
            //todo reducir el tamanio
            PlayerScale.OnHitPlayer.Invoke();
            UIBulletManager.OnBulletFired.Invoke();
        }
    }
    private void LookAtEnemy()
    {
        // transform.right = enemyPosition.position - transform.position;
        Vector3 direction = enemyPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
}
