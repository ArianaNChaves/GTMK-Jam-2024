using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Buttons")] 
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;

    [Header("Panels")] 
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Data")] 
    [SerializeField] private ScenesSO sceneData;
    [SerializeField] private BulletDataSO bulletData;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
    }
    
    private void OnPlayButtonClicked()
    {
        sceneData.ResetPath();
        sceneData.NextScene();
        bulletData.currentBullets = 0;
        Debug.Log("play");
    }

    private void OnCreditsButtonClicked()
    {
        creditsPanel.SetActive(!creditsPanel.activeInHierarchy);
    }

    private void OnExitButtonClicked()
    {
        Debug.Log("exit");
    }

    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
    }
}
