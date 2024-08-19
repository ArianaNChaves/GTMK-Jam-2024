using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class borrar : MonoBehaviour
{
    public ScenesSO sceneData;

    public void OnButtonCLicked()
    {
        sceneData.NextScene();
    }
}
