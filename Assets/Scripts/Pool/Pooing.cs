using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private int ammoBullet;
    [SerializeField] private int maxBullet;
    private List<GameObject> BulletList;

    private void Start()
    {
        BulletList = new List<GameObject>();
        for (int i = 0; i < ammoBullet; i++)
        {
            GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullet.transform.SetParent(gameObject.transform);
            Bullet.SetActive(false);
            BulletList.Add(Bullet);
        }
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in BulletList)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                return bullet.gameObject;
            }
        }
        if (BulletList.Count < maxBullet)
        {
            GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            BulletList.Add(Bullet);
            Bullet.transform.SetParent(gameObject.transform);
            StartCoroutine(DestroyBullet(Bullet));
            Debug.Log("Nueva bala " + BulletList.Count);
            return Bullet;
        }
        else
        {
            Debug.Log("No more bullets " + BulletList.Count);
            return null;
        }
    }

    public void ReturnBullet(GameObject Bullet)
    {
        Bullet.SetActive(false);
    }

    private IEnumerator DestroyBullet(GameObject Bullet)
    {
        yield return new WaitForSeconds(5f);
        if (!Bullet.activeSelf)
        {
            BulletList.Remove(Bullet);
            Destroy(Bullet);
        }
    }

}