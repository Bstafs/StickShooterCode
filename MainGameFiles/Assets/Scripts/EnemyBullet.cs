using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	public int damage = 10;
	public float timeToDestroy;
	public float hitForce;
	public LayerMask whatToHit;

	

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
		PlayerHealth Player = collision.GetComponent<PlayerHealth>();

		if (collision.CompareTag("Player"))
		{
			Player.Damage(damage);
		
			Debug.Log("Player Hit");
		}
		else if (Player != null)
		{
			Debug.Log("Missed!");

		}
		Destroy(gameObject);
	}
	IEnumerator AutoDestroy(float _time)
	{
		yield return new WaitForSeconds(_time);
		Destroy(gameObject);
	}
}

