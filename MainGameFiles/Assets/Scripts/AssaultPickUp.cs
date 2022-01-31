using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultPickUp : MonoBehaviour
{

	public GameObject weaponOnGround;
	public GameObject myWeaponAssault;
	public bool assaultPickedUp;
    public Animator playerAnimation;


    void Start()
    {
		myWeaponAssault.SetActive(false);
		assaultPickedUp = false;
        playerAnimation.SetBool("assaultSwitched", false);
       
    }

   
    void Update()
    {
		myWeaponAssault.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player" )
		{
			myWeaponAssault.SetActive(true);
			weaponOnGround.SetActive(false);
            playerAnimation.SetBool("assaultSwitched", true);
            
			assaultPickedUp = true;
		}
	}
}
