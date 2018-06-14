using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float moveSpeed = 12;
	private float jumpForce = 12;
	public bool isMirrored;

	private float jumpTime = 0.25f;
	private float jumpTimeCounter;

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

		jumpTimeCounter = jumpTime;
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
		myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
 
		if(grounded  && Input.GetKeyDown(KeyCode.Space)) {
			if(!isMirrored) { 
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			} else {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
			}
		}

		if(Input.GetKey(KeyCode.Space)) {
			if(jumpTimeCounter > 0){
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce); 
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			jumpTimeCounter = 0;
		}

		if(grounded) {
			jumpTimeCounter = jumpTime;
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
