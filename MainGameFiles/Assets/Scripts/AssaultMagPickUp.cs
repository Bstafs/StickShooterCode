using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultMagPickUp : MonoBehaviour
{


	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerMovement mag = collision.GetComponent<PlayerMovement>();
		if (collision.gameObject.tag == "Player")
		{
			mag.assaultCurrentMagCount += 1;
			Destroy(gameObject);
		}
	}
}

