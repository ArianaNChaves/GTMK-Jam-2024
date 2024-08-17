using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float reductionRate = 0.2f;
    [SerializeField] private float expandRate = 0.2f;
    [SerializeField] private float maxScaleRate = 7.0f;
    [SerializeField] private float minScaleRate = 2.0f;

    private Color _default;
    private Color _hit;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _default = _spriteRenderer.color;
        _hit = Color.white;
    }

    private void OnEnable()
    {
        EnemyMouth.OnHit += MouthHit;
    }

    private void OnDisable()
    {
        EnemyMouth.OnHit -= MouthHit;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            transform.localScale += new Vector3(transform.localScale.x * expandRate, transform.localScale.y * expandRate, transform.localScale.z * expandRate);
            if (transform.localScale.x >= maxScaleRate)
            {
                Debug.Log("Perdiste");
            }
        }
    }
    private void MouthHit()
    {
        HitFlash();
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (transform.localScale.x <= minScaleRate)
        {
            Debug.Log("Ganaste");
        }
    }
    private void HitFlash()
    {
        _spriteRenderer.color = Color.Lerp(_default, _hit, 0.5f);
        Invoke(nameof(ReturnToNormalColor), 0.2f);
    }

    private void ReturnToNormalColor()
    {
        _spriteRenderer.color = _default;
    }
}
