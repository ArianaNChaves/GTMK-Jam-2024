using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMusic("Final");
    }

}
