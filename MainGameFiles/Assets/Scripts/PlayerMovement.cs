using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
	// Movement
	public float speed;
	private Rigidbody2D rb;
	private float inputHorizontal;
	private float LsHorizontal;
	private float LsVertical;
	
	// Ladder
	public LayerMask whatIsLadder;
	private bool isClimbing;
	public float climbSpeed;
	
	private float inputVertical;
	public float distance;
	


	// Jumping
	public bool isGrounded;
	public Transform groundPos;
	public float checkRadius;
	public float JumpHeight;
	private bool isJumping;
	public float jumpTime;
	private float jumpTimeCounter;
	public LayerMask whatIsGround;
	// Fall Damage
	public float maxFallForce;
	public float baseFallDamage;
	private float fallforce;
	private bool canTakeFallDamage = false;

	// Some Stuff
	public Transform assualtRifle;
	public Transform pistol;
    public GameObject player;

	public Animator playerAnimation;
	
	// Dodging
     public bool isDodging;
   public float dodgeWaitTime = 1f;

	public int pistolCurrentMagCount;
	public int assaultCurrentMagCount;


	public TextMeshProUGUI pistolCountText;
	public TextMeshProUGUI assaultCountText;

	//public Gun playerShoot;

	public bool facingRight;
    public AssaultPickUp assaultPickup;
    public WeaponSwitcher switcher;
    public PistolPickUp pistolPickup;




	void Start()
	{
		playerAnimation = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		isClimbing = false;
		isJumping = false;
        
	}

	void FixedUpdate()
	{
		inputHorizontal = Input.GetAxisRaw("Horizontal");

		LsHorizontal = Input.GetAxisRaw("LeftStickHorizontal");
		LsVertical = Input.GetAxisRaw("LeftStickVertical");

	    rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

		Vector3 moveDirection = new Vector3(LsHorizontal, LsVertical, 0.0f);


		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
		RaycastHit2D hitInfoDown = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsLadder);

		Health playerHealth = GetComponent<Health>();

		if (hitInfo.collider != null)
		{
			if (LsVertical > 0) // up the ladder
			{
				isClimbing = true;

			}
		}
		else
		{
			isClimbing = false;

		}
		if (hitInfoDown.collider != null) // down the ladder
		{
			if (LsVertical < 0)
			{
				isClimbing = true;
			}
		}
		else
		{
			isClimbing = false;
			
		}

		if (isClimbing == true)
		{
			inputVertical = Input.GetAxisRaw("Vertical");

			rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);

			rb.gravityScale = 0;
		}
		else
		{
			rb.gravityScale = 3;

		}

		if(!isGrounded)
		{
			float Velocity = Mathf.Abs(rb.velocity.y);
			fallforce = Velocity;
			canTakeFallDamage = true;
		}
		if(isGrounded && canTakeFallDamage == true)
		{
			if(fallforce > maxFallForce)
			{
				float damage = Mathf.RoundToInt (fallforce * baseFallDamage);
				fallforce = 0;
				print("Took" + damage.ToString() + "of damage");
				playerHealth.Damage(damage);
			}
		}

	}
	void Update()
	{
		pistolCountText.text = "Pistol Mags: " + pistolCurrentMagCount;
		assaultCountText.text = "Assault Mags: " + assaultCurrentMagCount;

		if (inputHorizontal > 0) // Going Right
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			facingRight = true;
		}
		if (inputHorizontal < 0) // Going Left
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
			facingRight = false;
		}
		if (inputHorizontal == 0)
		{
			playerAnimation.SetBool("isRunning", false);
		}
		else
		{
			playerAnimation.SetBool("isRunning", true);
            
		}
        if(inputHorizontal == 0 && assaultPickup.assaultPickedUp == true) 
        {
            playerAnimation.SetBool("isRunningAssault", false);
        }
        else
        {
            playerAnimation.SetBool("isRunningAssault", true);
            playerAnimation.SetBool("weaponSwitchedRunning", true);
        }
        if(inputHorizontal == 0 & pistolPickup.pistolPickedUp == true)
        {
            playerAnimation.SetBool("isRunningPistol", false);
           
        }
        else
        {
            playerAnimation.SetBool("isRunningPistol", true);
            playerAnimation.SetBool("weaponSwitchedRunning", false);
        }


		isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

		if(isGrounded == true && Input.GetButtonDown("ControllerButtonA") && assaultPickup.assaultPickedUp == false && isJumping == false)
		{
			playerAnimation.SetTrigger("TakeOff");
			isJumping = true;
			
			jumpTimeCounter = jumpTime;
			
			rb.velocity = Vector2.up * JumpHeight;

		}
        else if (isGrounded == true && Input.GetButtonDown("ControllerButtonA") && assaultPickup.assaultPickedUp == true && switcher.selectedWeapon == 0 && isJumping == false)
        {
            playerAnimation.SetTrigger("TakeOffAssault");
            isJumping = true;

            StartCoroutine(JumpTimer());
            jumpTimeCounter = jumpTime;

            rb.velocity = Vector2.up * JumpHeight;


        }
        else if (isGrounded == true && Input.GetButtonDown("ControllerButtonA") && pistolPickup.pistolPickedUp == true && switcher.selectedWeapon == 1 && isJumping == false)
        {
            playerAnimation.SetTrigger("TakeOffPistol");
			isJumping = true;

            jumpTimeCounter = jumpTime;

            rb.velocity = Vector2.up * JumpHeight;
        }
        if (isGrounded == true)
		{
			playerAnimation.SetBool("isJumping", false);
		}
		else
		{
			playerAnimation.SetBool("isJumping", true);
		}
        if(isGrounded == true && assaultPickup.assaultPickedUp == true)
        {
            playerAnimation.SetBool("isJumpingAssault", false);
        }
        else
        {
            playerAnimation.SetBool("isJumpingAssault", true);
        }
        if(isGrounded == true && pistolPickup.pistolPickedUp == true)
        {
            playerAnimation.SetBool("isJumpingPistol", false); 
        }
        else
        {
            playerAnimation.SetBool("isJumpingPistol", true);
        }
		if (Input.GetAxisRaw("ControllerButtonA") > 0 && isJumping == true)
		{
			if (jumpTimeCounter > 0)
			{
				rb.velocity = Vector2.up * JumpHeight;
				jumpTimeCounter -= Time.deltaTime;
				canTakeFallDamage = false;
			}
			else
			{
				isJumping = false;
			}
		}
		if(Input.GetAxisRaw("ControllerButtonA") > 0)
		{
			isJumping = false;
			canTakeFallDamage = false;
		}

		if (Input.GetKey(KeyCode.LeftControl) && isDodging == false)
		{
			Dodge();
		}
		if (isDodging == false)
		{
			playerAnimation.SetBool("isDodging", false);

		}
		
	}


	void Dodge()
    {
        StartCoroutine(dodgeTime());
    }
    IEnumerator dodgeTime()
    {
        isDodging = true;
        playerAnimation.SetTrigger("isDodging");
        yield return new WaitForSeconds(dodgeWaitTime);
        isDodging = false;

    }
    IEnumerator JumpTimer()
    {

        playerAnimation.SetTrigger("TakeOffAssault");
        isJumping = true;
        jumpTimeCounter = jumpTime;
        rb.velocity = Vector2.up * JumpHeight;
        yield return new WaitForSeconds(1);
        isJumping = false;

    }
}


