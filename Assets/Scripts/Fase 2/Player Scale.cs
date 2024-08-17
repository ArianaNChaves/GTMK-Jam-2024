using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public static Action OnHitPlayer;
    
    [SerializeField] private float reductionRate = 0.05f;
    [SerializeField] private float minRate = 0.05f;

    
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
        OnHitPlayer += ReduceScale;
    }
    private void OnDisable()
    {
        OnHitPlayer -= ReduceScale;
    }

    private void ReduceScale()
    {
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        HitFlash();
        UIBulletManager.OnBulletFired.Invoke();
        //TODO when run out of bullets, back to scene 1
        if (transform.localScale.x <= minRate)
        {
            Debug.Log("Chiquito, volver a juntar balas");
        }
    }
    private void HitFlash()
    {
        _spriteRenderer.color = Color.Lerp(_default, _hit, 0.5f);
        Invoke(nameof(ReturnToNormalColor), 0.3f);
    }

    private void ReturnToNormalColor()
    {
        _spriteRenderer.color = _default;
    }
}
