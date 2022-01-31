using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
	public GameObject bullet1;
	public GameObject bullet2;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision != null)
		{
			if (collision.tag == "Bullet1")
			{
				Destroy(bullet1 as GameObject);

			}
			else if (collision.tag == "Bullet2")
			{
				Destroy(bullet2 as GameObject) ;
			}


		}
	
	}

}
