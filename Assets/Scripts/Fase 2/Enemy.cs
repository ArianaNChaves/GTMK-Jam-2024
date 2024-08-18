using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public static Action EnemyHit;
    
    [SerializeField] private float reductionRate = 0.2f;
    [SerializeField] private float expandRate = 0.2f;
    [SerializeField] private ScenesSO sceneData;
    [SerializeField] private BulletDataSO bulletData;
    [SerializeField] private EnemySO enemyData;

    private int _health;
    private Color _default;
    private Color _hitOut;
    private Color _hitIn;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _health = enemyData.GetMaxHealth();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _default = _spriteRenderer.color;
        _hitIn = Color.white;
        _hitOut = Color.black;
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
            EnemyHit?.Invoke();
            HitOutFlash();
            transform.localScale += new Vector3(transform.localScale.x * expandRate, transform.localScale.y * expandRate, transform.localScale.z * expandRate);
            if (bulletData.currentBullets <= 0 && _health > 0)
            {
                Debug.Log("Perdiste");
                //todo DSACAR ESTA MIERDA DE ACA
            }
        }
    }
    private void MouthHit()
    {
        _health--;
        HitInFlash();
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (_health == 0)
        {
            Debug.Log("Ganaste");
        }
    }
    private void HitInFlash()
    {
        _spriteRenderer.color = Color.Lerp(_default, _hitIn, 0.5f);
        Invoke(nameof(ReturnToNormalColor), 0.2f);
    }
    private void HitOutFlash()
    {
        _spriteRenderer.color = Color.Lerp(_default, _hitOut, 0.5f);
        Invoke(nameof(ReturnToNormalColor), 0.2f);
    }
    private void ReturnToNormalColor()
    {
        _spriteRenderer.color = _default;
    }
}
