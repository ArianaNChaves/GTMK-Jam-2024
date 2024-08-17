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
    private Rigidbody2D rb2D;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;
    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        SR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        currentTime = maxTime;
        BulletType();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        Vector2 direction = target.position - transform.position;
        transform.right = direction;
        rb2D.velocity = transform.right * speed;

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (currentTime <= 0)
        {
            pool.GetComponent<Pool>().ReturnBullet(gameObject);
            currentTime = maxTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bool Match;
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == BulletTag)
            {
                Match = true;
                player.GetComponent<PlayerControl>().ChangeScale(Match);
            }
            else
            {
                Match = false;
                player.GetComponent<PlayerControl>().ChangeScale(Match);
            }
        }

        Return();
        pool.GetComponent<Pool>().ReturnBullet(gameObject);
    }

    private void BulletType()
    {
        int randNum = Random.Range(0, 100);

        if (randNum % 2 == 0)
        {
            BulletTag = "Blue";
            SR.color = Color.blue;
        }
        else
        {
            BulletTag = "Red";
            SR.color = Color.red;
        }
    }
    private void Return()
    {
        BulletTag = null;
        SR.color = Color.white;
    }
}
