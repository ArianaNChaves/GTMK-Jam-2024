using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
public class BulletDataSO : ScriptableObject
{
    public int currentBullets;
    public int maxBullets = 10;
}

