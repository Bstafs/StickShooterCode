using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField]
	GameObject bulletPrefab;
	[SerializeField]
	Transform weaponTip;

	public float fireRate;
	public float damage = 25f;
	public LayerMask whatToHit;
	public float range;

	float timeFire = 0;

	public float hitForce;






	public void OnShoot()
	{
		if (fireRate == 0)
		{
			OnShoot();
		}
		else
		{
			if (Time.time > timeFire)
			{
				timeFire = Time.time + 1 / fireRate;
				Shoot();
			}
		}

	}

	void Shoot()
	{
		Vector3 firePos = new Vector3(weaponTip.position.x, weaponTip.position.y, weaponTip.position.z);



		RaycastHit2D hit = Physics2D.Raycast(firePos, transform.TransformDirection(Vector3.forward), range, whatToHit);

		Debug.DrawRay(firePos, transform.TransformDirection(Vector3.forward) * range, Color.green);  // drawing a green line in builder

		if (hit.collider != null)
		{
			if (hit.collider.tag == "Enemies")
			{
				hit.collider.gameObject.GetComponent<Health>().Damage(damage); // dealing damage

				if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
				{
					hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-hit.normal * hitForce); // adding force on hit

				}
				Debug.Log("Enemy Hit");
			}
			else
			{
				Debug.Log("We Have Hit something");
			}
		}
		DrawBullet();
	}



	void DrawBullet()
	{		
		Instantiate(bulletPrefab, weaponTip.position, weaponTip.rotation);
	}

	

}