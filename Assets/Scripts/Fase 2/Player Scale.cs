using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;

public class PlayerScale : MonoBehaviour
{
    public static Action OnHitPlayer;
    
    [SerializeField] private float reductionRate = 0.05f;
    [SerializeField] private  ScenesSO sceneData;
    [SerializeField] private  BulletDataSO bulletData;
    
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
        //todo aca va el codigo
        UIBulletManager.OnBulletFired.Invoke();

        //todo Cambiar mas smooth la escala
        transform.localScale -= new Vector3(transform.localScale.x * reductionRate, transform.localScale.y * reductionRate, transform.localScale.z * reductionRate);
        HitFlash();
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
