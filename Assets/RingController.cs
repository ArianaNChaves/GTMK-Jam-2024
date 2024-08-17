using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

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
                Invoke(nameof(ChangeScale), 1f);
                currentTime = maxTime;
            }

            if ((transform.localScale) / 0.21f == player.localScale)
            {
                CanChange = false;
                Invoke(nameof(ChangeScale), 0.3f);
                currentTime = maxTime;
                UIBulletManager.OnBulletAdded.Invoke();
                //TODO when reaches max bullets (10) change scene
            }
        }
    }

    private void ChangeScale()
    {
        int randNum = Random.Range(0, 20);

        switch (randNum % 4)
        {
            case 0:
                transform.localScale = new Vector2(1 * 0.21f, 1 * 0.21f);
                break;
            case 1:
                transform.localScale = new Vector2(2 * 0.21f, 2 * 0.21f);
                break;
            case 2:
                transform.localScale = new Vector2(3 * 0.21f, 3 * 0.21f);
                break;
            case 3:
                transform.localScale = new Vector2(4 * 0.21f, 4 * 0.21f);
                break;
        }
        CanChange = true;
        Debug.Log("Cambio " + randNum);
    }

    private void PreChange(){
        Invoke(nameof(ChangeScale), 0.3f);
    }

}
