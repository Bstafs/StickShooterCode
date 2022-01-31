using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
	public Transform player;
	private Rigidbody2D rb;
	private Vector2 movement;
	public float moveSpeed = 3;

	// Enemy Shooting
	private float timeBetweenShots;
	public float startTimeBetweenShots;
	public GameObject projectile;
	public Transform enemyFirePoint;

	// Detect The Player
	public float playerRange;
	private PlayerMovement thePlayer;
	public float stoppingDistance;
	public bool playerDetected;
	

	//Animation
	public Animator enemyAnimation;
	public Transform bulletRotation;





	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		timeBetweenShots = startTimeBetweenShots;
		enemyAnimation = GetComponent<Animator>();
		thePlayer = FindObjectOfType<PlayerMovement>();
		playerDetected = false;
	    
	}
	void FixedUpdate()
	{


		if (Vector3.Distance(transform.position, thePlayer.transform.position) < playerRange)
		{
			Vector3 playerDirection = thePlayer.transform.position - transform.position;

			rb.velocity = playerDirection.normalized * moveSpeed;

			enemyAnimation.SetBool("isRunning", true);

			playerDetected = true;

			

			if (player.position.x > transform.position.x)
			{
				transform.eulerAngles = new Vector3(0, 180, 0); // Looking Right  
				bulletRotation.eulerAngles = new Vector3(0, 0, -90);
				
			}
			else if (player.position.x < transform.position.x)
			{
				transform.eulerAngles = new Vector3(0, 0, 0); // Looking Left
				bulletRotation.eulerAngles = new Vector3(0, 0, 90);
				
			}




			if (timeBetweenShots <= 0)
			{
				Instantiate(projectile, enemyFirePoint.position, bulletRotation.rotation);
				timeBetweenShots = startTimeBetweenShots;
			}
			else
			{
				timeBetweenShots -= Time.deltaTime;
			}
		}
		else if (Vector3.Distance(transform.position, thePlayer.transform.position) > playerRange)
		{
			rb.velocity = Vector2.zero;
			enemyAnimation.SetBool("isRunning", false);
			playerDetected = false;
		}

		if (Vector3.Distance(transform.position, thePlayer.transform.position) <= stoppingDistance && playerDetected == true)
		{
			rb.velocity = Vector2.zero;
			enemyAnimation.SetBool("isRunning", false);
		}
		else
		{
			playerDetected = false;
			enemyAnimation.SetBool("isRunning", true);
		}




	}

}
