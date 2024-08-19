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
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button creditsBackButton;

    [Header("Panels")] 
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject buttonsPanel;

    [Header("Data")] 
    [SerializeField] private ScenesSO sceneData;
    [SerializeField] private BulletDataSO bulletData;
    [SerializeField] private AudioSO audioData;
    
    [Header("Sliders")] 
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);
        creditsBackButton.onClick.AddListener(OnCreditsBackButtonClicked);
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        AudioManager.Instance.MusicVolume(audioData.GetMusicVolume());
        musicVolume.value = audioData.GetMusicVolume();
        
        AudioManager.Instance.SfxVolume(audioData.GetSFXVolume());
        sfxVolume.value = audioData.GetSFXVolume();
        
        AudioManager.Instance.PlayMusic("Main Menu");
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
        buttonsPanel.SetActive(false);
    }
    private void OnExitButtonClicked()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
        buttonsPanel.SetActive(false);
    }
    private void OnSettingsBackButtonClicked()
    {
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    private void OnCreditsBackButtonClicked()
    {
        buttonsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void SetMusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicVolume.value);
        audioData.SetMusicVolume(musicVolume.value);
    }
    public void SetSFXVolume()
    {
        AudioManager.Instance.SfxVolume(sfxVolume.value);
        audioData.SetSFXVolume(sfxVolume.value);
    }
}
