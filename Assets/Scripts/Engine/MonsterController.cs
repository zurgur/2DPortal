using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float health = 100;

    private float moveSpeed = 10;

    public bool isMirrored;

    private Rigidbody2D myRigidBody;

    private Collider2D myCollider;

    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {

        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);



        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);

    }
}
