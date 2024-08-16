using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [Header("Pool")]

    [SerializeField] private GameObject pool;

    [Header("Speed")]
    [SerializeField] private float speed;

    [Header("Player")]
    private GameObject player;
    private Transform target;

    [Header("Type")]

    private string BulletTag;
    private SpriteRenderer SR;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;
    private void Awake()
    {
        currentTime = maxTime;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        BulletType();
    }

    private void Update()
    {
        currentTime-=Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (currentTime <= 0)
        {
            pool.GetComponent<Pool>().ReturnBullet(gameObject);
            currentTime = maxTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");

        bool Match = true;

        if (other.gameObject.tag != BulletTag)
        {
            Match = false;
        }

        player.GetComponent<PlayerControl>().ChangeScale(Match);
        pool.GetComponent<Pool>().ReturnBullet(gameObject);
    }

    private void BulletType()
    {
        int randNum = Random.Range(0, 100);
        Debug.Log(randNum);
        if (randNum % 2 == 0)
        {
            BulletTag = "Blue";
            SR.color = Color.blue;
        }else
        {
            BulletTag = "Red";
            SR.color = Color.blue;
        }
    }
    private void OnDisable() {
        BulletTag = null;
        SR.color = Color.white;
    }
}
