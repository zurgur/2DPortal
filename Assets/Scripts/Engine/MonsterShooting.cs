using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{

    public GameObject Bullet;
    Vector2 bulletPos;
    public float Damage = 5;
    public float fireRate = 0.5f;

    float timeToFire = 0.0f;
    Transform firePoint;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint located");
        }

    }

    // Update is called once per frame
    void Update()
    {  
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {

        Instantiate(Bullet, firePoint.transform.position, Quaternion.identity);

    }
}