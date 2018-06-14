using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    public float velX = 5f;
    public float velY = 0f;
    public Rigidbody2D rb;
    public float time = 2f;

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
}
