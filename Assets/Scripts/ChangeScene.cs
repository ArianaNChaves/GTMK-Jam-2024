using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private ScenesSO scenesData;

    private PlayableDirector  _timeline;
    private float _duration;

    private void Awake()
    {
        _timeline = GetComponent<PlayableDirector>();
    }
    private void Start()
    {
        _duration = (float)_timeline.duration;
        Invoke(nameof(OnEndTimeline),_duration);
    }

    private void OnEndTimeline()
    {
        scenesData.NextScene();
    }
}
