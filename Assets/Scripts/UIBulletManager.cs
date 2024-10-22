using UnityEngine;
using UnityEngine.UI;
using System;

public class UIBulletManager : MonoBehaviour
{
    public Image[] bulletSlots;
    public Sprite filledSlotSprite;
    public BulletDataSO bulletData;

    public static Action OnBulletAdded;
    public static Action OnBulletFired;

    private void Start()
    {
        OnBulletAdded += AddBullet;
        OnBulletFired += FireBullet;

        UpdateUI();
    }

    private void OnDestroy()
    {
        OnBulletAdded -= AddBullet;
        OnBulletFired -= FireBullet;
    }

    private void AddBullet()
    {
        AudioManager.Instance.PlayEffect("Add Bullet");

        bulletData.currentBullets = Mathf.Clamp(bulletData.currentBullets + 1, 0, bulletData.maxBullets);
        UpdateUI();
    }

    private void FireBullet()
    {
        if (bulletData.currentBullets <= 0) return;
        bulletData.currentBullets--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (var i = 0; i < bulletSlots.Length; i++)
        {
            if (i < bulletData.currentBullets)
            {
                bulletSlots[i].color = Color.white;
            }
            else
            {
                bulletSlots[i].color = Color.clear;
            }
        }
    }

    public static void InvokeAddBulletEvent()
    {
        OnBulletAdded?.Invoke();
    }

    public static void InvokeFireBulletEvent()
    {
        OnBulletFired?.Invoke();
    }
}