using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BulletDataSO bulletData;
    [SerializeField] private ScenesSO scenesData;

    private int _successCount;
    private int _failCount;
    
    private void OnEnable()
    {
        EnemyMouth.OnHit += SuccessCount;
        Enemy.EnemyHit += FailCount;
        PlayerScale.OnHitPlayer += CheckCondition;

    }
    private void OnDisable()
    {
        EnemyMouth.OnHit -= SuccessCount;
        Enemy.EnemyHit -= FailCount;
        PlayerScale.OnHitPlayer -= CheckCondition;
    }
    private void SuccessCount()
    {
        _successCount++;
        CheckCondition();
    }
    private void FailCount()
    {
        _failCount++;
        CheckCondition();
    }

    private void CheckCondition()
    {
        if (bulletData.currentBullets <= 0)
        {
            if (_successCount >= 8)
            {
                Debug.Log("Win Battle");
                scenesData.NextScene();
            }

            if (_failCount >= 3)
            {
                Debug.Log("Lose Battle");
                scenesData.LastScene();
            } 
        }
        
    }
}
