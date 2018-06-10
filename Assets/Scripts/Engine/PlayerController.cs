using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float moveSpeed = 10;
	private float jumpForce = 7;
	public bool isMirrored;

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
		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

		myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
 
		if(grounded && Input.GetKeyDown(KeyCode.Space)) {
			if(!isMirrored) {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			} else {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
			}
		}

		myAnimator.SetFloat ( "Speed", myRigidBody.velocity.x );
		myAnimator.SetBool ( "Grounded", grounded); 
		
	}
}
