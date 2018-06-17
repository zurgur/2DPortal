using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Shooting : MonoBehaviour
{
    public bool Shotgun = false;
    public GameObject Bullet;
    Vector2 bulletPos;
    public float Damage = 10;
    public float fireRate = 0.5f;

    [SerializeField]
    private bool player1;

    float timeToFire = 0.0f;
    Transform firePoint;

    // Use this for initialization
    void Awake()
    {
        Shotgun = PlayerPrefsManager.IsItemnlocked(0);
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
            if(CrossPlatformInputManager.GetButton("Fire1") && player1)
            {
                Shoot();
            }
            if (CrossPlatformInputManager.GetButton("Fire2") && !player1)
            {
                Shoot();
            }
        }
        else
        {
            if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > timeToFire && player1)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
            if (CrossPlatformInputManager.GetButton("Fire2") && Time.time > timeToFire && !player1)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        FindObjectOfType<CameraController>().StartShake(0.1f, 0.1f);
        FindObjectOfType<AudioManager>().play("bulletFire");

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