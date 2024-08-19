using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy Data", menuName = "ScriptableObjects/Enemy Data")]

public class EnemySO : ScriptableObject
{
    [SerializeField] private int MaxHealth;
    
    public int GetMaxHealth()
    {
        return MaxHealth;
    }
}
