using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool Shotgun = true;
    public GameObject Bullet;
    Vector2 bulletPos;
    public float Damage = 10;
    public float fireRate = 0.5f;

    float timeToFire = 0.0f;
    Transform firePoint;

    // Use this for initialization
    void Awake()
    {
    GameObject Bullet = GameObject.Find("Bullet");

    firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint located");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        if (Shotgun)
        {
            Bullet.GetComponent<BulletControl>().time = 1f;
            Instantiate(Bullet, firePoint.transform.position, Quaternion.identity);
            Bullet.GetComponent<BulletControl>().velY = 1;
            Instantiate(Bullet, firePoint.transform.position, Quaternion.identity);
            Bullet.GetComponent<BulletControl>().velY = -1;
            Instantiate(Bullet, firePoint.transform.position, Quaternion.identity);
            Bullet.GetComponent<BulletControl>().velY = 0;
            Bullet.GetComponent<BulletControl>().time = 2f;

        }
        else
        {
            Instantiate(Bullet, firePoint.transform.position, Quaternion.identity);
        }
    }
}