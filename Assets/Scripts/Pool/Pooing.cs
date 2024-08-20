using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    



    public void ReturnBullet(GameObject Bullet)
    {
        Destroy(Bullet);
    }

    private IEnumerator DestroyBullet(GameObject Bullet)
    {
        yield return new WaitForSeconds(10f);
        Destroy(Bullet);
        
    }

}