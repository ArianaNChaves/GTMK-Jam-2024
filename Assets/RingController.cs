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

    [Header("ChangeTimer")]
    private float preTime;
    [SerializeField] private float totTime;

    [Header("CanChange")]
    private bool CanChange;
    private void Awake()
    {
        preTime = totTime;
        CanChange = true;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (CanChange)
        {
            if (currentTime <= 0)
            {
                CanChange = false;
                preTime -= Time.deltaTime;
                Invoke(nameof(ChangeScale), 0.5f);
                currentTime = maxTime;
                /*if (preTime <= 0)
                {
                    //ChangeScale();
                    //currentTime = maxTime;
                    preTime = totTime;
                }*/

            }

            if ((transform.localScale) / 0.21f == player.localScale)
            {
                CanChange = false;
                preTime -= Time.deltaTime;
                Invoke(nameof(ChangeScale), 0.5f);
                currentTime = maxTime;
                /*if (preTime <= 0)
                {
                    //ChangeScale();
                    //currentTime = maxTime;
                    preTime = totTime;
                }*/
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

}
