using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickUp : MonoBehaviour
{

	public GameObject weaponOnGround;
	public GameObject myWeaponPistol;
	public bool pistolPickedUp;
    public Animator playerAnimation;

	void Start()
	{
		myWeaponPistol.SetActive(false);
		pistolPickedUp = false;
        playerAnimation.SetBool("pistolSwitched", false);
	}


	void Update()
	{
		myWeaponPistol.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			myWeaponPistol.SetActive(true);
			weaponOnGround.SetActive(false);
            playerAnimation.SetBool("pistolSwitched", true);

            pistolPickedUp = true;
		}

	}
}
