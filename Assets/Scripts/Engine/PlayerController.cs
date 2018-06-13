using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float moveSpeed = 10;
	private float jumpForce = 5;
	public bool isMirrored;
	private float jumpCount = 0;

	private Rigidbody2D myRigidBody;

	public bool grounded;
	public LayerMask whatIsGround; 

	private Collider2D myCollider;

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();

		myCollider = GetComponent<Collider2D>();

		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(jumpCount == 2) jumpCount = 0;

		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
		myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
 
		if((grounded || jumpCount == 1) && Input.GetKeyDown(KeyCode.Space)) {
			if(!isMirrored) {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			} else {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
			}
			jumpCount++;
		}

		myAnimator.SetFloat ( "Speed", myRigidBody.velocity.x );
		myAnimator.SetBool ( "Grounded", grounded); 
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "MonsterBullet(Clone)")
        {
            Destroy(other.gameObject);
            GetComponent<PlayerHealth>().HurtPlayer(5); 
        }

    }
}
