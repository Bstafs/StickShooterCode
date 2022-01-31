using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

	public int selectedWeapon;

	public Weapon weaponAssault;
	public PlayerMovement wep;
	public PistolPickUp pistol;
	public AssaultPickUp assault;

	public bool canSwitchWeapon;

	void Start()
    {		
		canSwitchWeapon = false;
		assault.myWeaponAssault.SetActive(false);
	}   

    void Update()
    {

		int prevSelectedWeapon = selectedWeapon;



		if (Input.GetKeyDown(KeyCode.Alpha1) && canSwitchWeapon == true && weaponAssault.isReloading == false && pistol.pistolPickedUp == true)
		{
			selectedWeapon = 0;
		}		

		if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && canSwitchWeapon == true && weaponAssault.isReloading == false && assault.assaultPickedUp == true)
		{
			selectedWeapon = 1;
			
		}
		if (Input.GetAxisRaw("RightBumper") == 1 && canSwitchWeapon == true && weaponAssault.isReloading == false && pistol.pistolPickedUp == true)
		{
			selectedWeapon = 0;
            wep.playerAnimation.SetBool("weaponSwitched", false);
		}

		if (Input.GetAxisRaw("LeftBumper") == 1 && transform.childCount >= 2 && canSwitchWeapon == true && weaponAssault.isReloading == false && assault.assaultPickedUp == true)
		{
			selectedWeapon = 1;
            wep.playerAnimation.SetBool("weaponSwitched", true);

		}


		if ( weaponAssault.isReloading == true )
        {
            canSwitchWeapon = false;
        }

		if (selectedWeapon == 0 && pistol.pistolPickedUp == false)
		{
			canSwitchWeapon = false;
		}
		if (selectedWeapon == 1 && assault.assaultPickedUp == false)
		{
			canSwitchWeapon = false;
		}
		if (pistol.pistolPickedUp == true && assault.assaultPickedUp == true)
		{
			canSwitchWeapon = true;		
			
		}

		if (selectedWeapon == 0)
		{
			pistol.myWeaponPistol.SetActive(false);
			
		}
		else
		{
			pistol.myWeaponPistol.SetActive(true);
			
		}
	    if (selectedWeapon == 1)
		{
			assault.myWeaponAssault.SetActive(false);
			
		}
	    else
		{
			assault.myWeaponAssault.SetActive(true);
			
		}
	

		if (prevSelectedWeapon != selectedWeapon && canSwitchWeapon == true && weaponAssault.isReloading == false || prevSelectedWeapon != selectedWeapon && canSwitchWeapon == true && weaponAssault.isReloading == false)
		{
			SelectWeapon();
		}

		
	}


	void SelectWeapon()
	{
		int i = 0;

		foreach (Transform weapon in transform)
		{
			if (i == selectedWeapon)
			{				
				weapon.gameObject.SetActive(true);
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
				i++;
		}
	}

}
