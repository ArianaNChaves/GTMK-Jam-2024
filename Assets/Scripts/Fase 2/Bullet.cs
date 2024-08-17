using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;

    private Vector3 _direction;
    private Rigidbody2D _rigidbody;
    private Transform _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initiate(Transform enemyTarget)
    {
        _target = enemyTarget;
    }
    void FixedUpdate()
    {
        Vector3 direction = _target.position - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}