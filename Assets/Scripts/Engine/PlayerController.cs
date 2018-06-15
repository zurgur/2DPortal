using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

	private float moveSpeed = 10;
	private float jumpForce = 12;

    [SerializeField]
    private bool playerOne;

	public bool isMirrored;

	private float speedMultiplier = 1.05f;
	private float speedIncreaseMilestone = 100f;
	private float speedMilestoneCount;

	private float jumpTime = 0.25f;
	private float jumpTimeCounter;

	private Rigidbody2D myRigidBody;

	public bool grounded;
	public LayerMask whatIsGround; 
	public Transform groundCheck;
	public float groundCheckRadius;
	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();

		myAnimator = GetComponent<Animator>();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {
		myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
 
		JumpingUpdate();

		if(transform.position.x > speedMilestoneCount) {

			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone *= speedMultiplier;

			moveSpeed *= speedMultiplier;
		}
 
		myAnimator.SetFloat ( "Speed", myRigidBody.velocity.x );
		myAnimator.SetBool ( "Grounded", grounded); 
		
	}

	void JumpingUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(grounded  && CrossPlatformInputManager.GetButton("Jump1") && playerOne) {
			if(!isMirrored) { 
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			} else {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
			}
		}

		if(CrossPlatformInputManager.GetButton("Jump1") && playerOne) {
			if(jumpTimeCounter > 0){
                if (!isMirrored)
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }
		}

		if(CrossPlatformInputManager.GetButtonUp("Jump1") && playerOne) {
			jumpTimeCounter = 0;
		}
        // player 2
        if (grounded && CrossPlatformInputManager.GetButton("Jump2") && !playerOne)
        {
            if (!isMirrored)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
            else
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
            }
        }
        
        if (CrossPlatformInputManager.GetButton("Jump2") && !playerOne)
        {
            if (jumpTimeCounter > 0)
            {
                if (!isMirrored)
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }
        }

        if (CrossPlatformInputManager.GetButtonUp("Jump2") && !playerOne)
        {
            jumpTimeCounter = 0;
        }
        
        if (grounded) {
			jumpTimeCounter = jumpTime;
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "MonsterBullet(Clone)")
        {
            Destroy(other.gameObject);
            GetComponent<PlayerHealth>().HurtPlayer(5); 
        }

    }
    public void Flip()
    {
        if(isMirrored) transform.position += new Vector3(0, 10, 0);
        else transform.position += new Vector3(0, -10, 0);
        isMirrored = !isMirrored;
        transform.Rotate(new Vector3(180,0,0));
        GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
    }
}
