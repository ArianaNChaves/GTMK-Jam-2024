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
    [SerializeField] private ScenesSO sceneData;
    [SerializeField] private BulletDataSO bulletData;

    private int _health = 10;
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
            if (bulletData.currentBullets <= 0 && _health > 0)
            {
                //todo HACER EN SCENE DATA UN METODO QUE TE LLEVE A LA ESCENA ANTERIOR (index -1)
                Debug.Log("Perdiste");
                sceneData.LastScene();
            }
        }
    }
    private void MouthHit()
    {
        _health--;
        HitFlash();
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        if (_health <= 0)
        {
            Debug.Log("Ganaste");
            sceneData.NextScene();
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
