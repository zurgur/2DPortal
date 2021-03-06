﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    public float velX = 5f;
    public float velY = 0f;
    public Rigidbody2D rb;
    public float time = 5f;
    public GameObject particle;
    public int damage = 10;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);

        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(other.tag == "PlayerOne" || other.tag == "PlayerTwo")
        {
            other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<bossHealth>())
        {
            other.gameObject.GetComponent<bossHealth>().hurtBoss(damage);
        }

    }
}
