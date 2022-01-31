using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	public int damage = 25;
	public float timeToDestroy;
	public float hitForce;
    public LayerMask whatToHit;
    private PlayerMovement rotation;


    
  

	 void Start()
	 {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * speed;
          
		
	}


	private void OnEnable()
	{
		StartCoroutine(AutoDestroy(timeToDestroy));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Health enemy = collision.GetComponent<Health>();
		Boss boss = collision.GetComponent<Boss>();

		if (collision.CompareTag("Enemies"))
		{
				enemy.Damage(damage);

				Debug.Log("Enemies Hit");
		}
		else if (enemy != null)
		{
			Debug.Log("Something Was Hit");
			
		}
		if (collision.CompareTag("Boss"))
		{
			boss.BossDamage(damage);

		}
		Destroy(gameObject);
	}
	IEnumerator AutoDestroy(float _time)
	{
		yield return new WaitForSeconds(_time);
		Destroy(gameObject);
	}
}
