using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using EasyTransition;
using Unity.Collections;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scenes Data", menuName = "ScriptableObjects/Scenes Data")]
public class ScenesSO : ScriptableObject
{
    [Header("Golden Path")]
    [SerializeField] private List<string> goldenPathList;
    
    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float LoadDelay;

    [Header("READ ONLY")] 
    [SerializeField] private string CurrentPath = "Main Menu";


    private int _index = 0;
    
    public void NextScene()
    {
        if (_index == 10)
        {
            TransitionManager.Instance().Transition(goldenPathList[0], transition, LoadDelay);
            _index = 0;
        }
        string scene = goldenPathList[_index + 1];
        _index++;
        CurrentPath = scene;
        TransitionManager.Instance().Transition(scene, transition, LoadDelay);
    }

    public void LastScene()
    {
        if (_index == 0) return;
        _index--;
        string scene = goldenPathList[_index];
        CurrentPath = scene;
        TransitionManager.Instance().Transition(scene, transition, LoadDelay);

    }
    
}
