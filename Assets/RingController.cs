using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using EasyTransition;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class RingController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;

    [Header("CanChange")]
    private bool CanChange;

    [Header("Components")]
    private Animator anims;
    
    [Header("Data")] 
    [SerializeField] private ScenesSO sceneData;

    public BulletDataSO bulletData;

    private void Awake()
    {
        CanChange = true;
        currentTime = maxTime;
        anims = GetComponent<Animator>();
        ChangeScale();
    }
    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (CanChange)
        {
            if (currentTime <= 1)
            {
                CanChange = false;
                anims.Play("TwinkleRing");
                currentTime = maxTime;
            }

            if ((transform.localScale) / 0.21f == player.localScale)
            {
                UIBulletManager.OnBulletAdded.Invoke();
                CanChange = false;
                Invoke(nameof(ChangeScale), 0.3f);
                currentTime = maxTime;
            }
            
            if (bulletData.currentBullets == bulletData.maxBullets)
            {
                //TODO Load new scene
                sceneData.NextScene();
                Debug.Log("Load new scene");
            }
        }

    }

    private void ChangeScale()
    {
        int randNum = Random.Range(0, 20);

        switch (randNum % 4)
        {
            //TODO Smooth Scale Change
            case 0:
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(1 * 0.21f, 1 * 0.21f), 1);
                break;
            case 1:
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(2 * 0.21f, 2 * 0.21f), 1);
                //transform.localScale = new Vector2(2 * 0.21f, 2 * 0.21f);
                break;
            case 2:
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(3 * 0.21f, 3 * 0.21f), 1);
                //transform.localScale = new Vector2(3 * 0.21f, 3 * 0.21f);
                break;
            case 3:
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(4 * 0.21f, 4 * 0.21f), 1);
                //transform.localScale = new Vector2(4 * 0.21f, 4 * 0.21f);
                break;
        }
        CanChange = true;
    }

}
