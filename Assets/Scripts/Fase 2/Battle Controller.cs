using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BulletDataSO bulletData;
    [SerializeField] private ScenesSO scenesData;
    [SerializeField] private EnemySO enemyData;

    private int _successCount;
    private int _failCount;
    private bool _firstCheck = false;
    private int _enemyMaxHealth;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _enemyMaxHealth = enemyData.GetMaxHealth();
    }

    private void OnEnable()
    {
        EnemyMouth.OnHit += SuccessCount;
        Enemy.EnemyHit += CheckCondition;
        PlayerScale.OnHitPlayer += CheckCondition;

    }
    private void OnDisable()
    {
        EnemyMouth.OnHit -= SuccessCount;
        Enemy.EnemyHit -= CheckCondition;
        PlayerScale.OnHitPlayer -= CheckCondition;
    }
    private void SuccessCount()
    {
        _successCount++;
        CheckCondition();
    }
    
    private void CheckCondition()
    {
        if (bulletData.currentBullets <= 0 && !_firstCheck)
        {
            _firstCheck = true;
            if (_successCount >= _enemyMaxHealth)
            {
                Debug.Log("Win Battle");
                scenesData.NextScene();
            }
            else
            {
                Debug.Log("Lose Battle");
                scenesData.LastScene(); 
            }

        }
        
    }
}
